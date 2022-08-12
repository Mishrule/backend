using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TimeTableUI.Contracts;
using TimeTableUI.Models.VMs;
using TimeTableUI.Services;
using TimeTableUI.Static;

namespace TimeTableUI.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IGroupRepository _groupRepository;
        public FileUploadController(IRoomRepository roomRepository, ILecturerRepository lecturerRepository, ICourseRepository courseRepository, IGroupRepository groupRepository)
        {
            _roomRepository = roomRepository;
            _lecturerRepository = lecturerRepository;
            _courseRepository = courseRepository;
            _groupRepository = groupRepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Import()
        {
            return View();
        }
        public IActionResult ImportLecturers()
        {
            return View();
        }

        public IActionResult ImportCourses()
        {
            return View();
        }
        public IActionResult ImportCourseGroups()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            try
            {
                var list = new List<RoomVM>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowcount; row++)
                        {
                            list.Add(new RoomVM
                            {
                                room = new Rooms()
                                {
                                    name = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                    lab = worksheet.Cells[row, 2].Value.ToString().Equals("true") ? true : false,
                                    size = Convert.ToInt32(worksheet.Cells[row, 3].Value.ToString().Trim())
                                }
                                
                            });

                        }
                    }
                }

                foreach (var data in list)
                {
                  await  _roomRepository.Create(Endpoints.RoomEndpoint, data);
                }

                return RedirectToAction("Import");
                ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> ImportLecturers(IFormFile file)
        {
            try
            {
                var list = new List<RootLecturerVM>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowcount; row++)
                        {
                            list.Add(new RootLecturerVM
                            {
                                prof = new LecturerVM()
                                {
                                    id = Convert.ToInt32(worksheet.Cells[row, 1].Value.ToString().Trim()),
                                    name = worksheet.Cells[row, 2].Value.ToString().Trim()
                                    //lab = worksheet.Cells[row, 2].Value.ToString().Equals("true") ? true : false,
                                    //size = Convert.ToInt32(worksheet.Cells[row, 3].Value.ToString().Trim())
                                }

                            });

                        }
                    }
                }

                foreach (var data in list)
                {
                    await _lecturerRepository.Create(Endpoints.LecturerEndpoint, data);
                }

                return RedirectToAction("ImportLecturers");
                ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> ImportCourses(IFormFile file)
        {
            try
            {
                var list = new List<CourseVM>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowcount; row++)
                        {
                            list.Add(new CourseVM()
                            {
                                course = new Course()
                                {
                                    id = Convert.ToInt32(worksheet.Cells[row, 1].Value.ToString().Trim()),
                                    name = worksheet.Cells[row, 2].Value.ToString().Trim()
                                    //lab = worksheet.Cells[row, 2].Value.ToString().Equals("true") ? true : false,
                                    //size = Convert.ToInt32(worksheet.Cells[row, 3].Value.ToString().Trim())
                                }

                            });

                        }
                    }
                }

                foreach (var data in list)
                {
                    await _courseRepository.Create(Endpoints.CourseEndpoint, data);
                }

                return RedirectToAction("ImportCourses");
                ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> ImportCourseGroups(IFormFile file)
        {
            try
            {
                var list = new List<GroupVM>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowcount; row++)
                        {
                            list.Add(new GroupVM()
                            {
                                group = new Group()
                                {
                                    id = Convert.ToInt32(worksheet.Cells[row, 1].Value.ToString().Trim()),
                                    name = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                    size = Convert.ToInt32(worksheet.Cells[row, 3].Value.ToString().Trim())
                                    //lab = worksheet.Cells[row, 2].Value.ToString().Equals("true") ? true : false,
                                    //size = Convert.ToInt32(worksheet.Cells[row, 3].Value.ToString().Trim())
                                }

                            });

                        }
                    }
                }

                foreach (var data in list)
                {
                    await _groupRepository.Create(Endpoints.GroupEndpoint, data);
                }

                return RedirectToAction("ImportCourseGroups");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }




    }
}
