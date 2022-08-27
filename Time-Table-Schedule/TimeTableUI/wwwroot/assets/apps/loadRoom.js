function loadData() {
	$("#_roomDataTable").DataTable({
		pageLength: 50,
		processing: true,
		serverSide: true,
		lengthMenu: [10, 25, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 50000, 100000],
		filter: true,
		drawCallback: function () {
			$("#dataTable_wrapper").children().eq(1).css("overflow", "auto");
		},
		ajax: {
			"url": $('#base_url').text() + "/Room/GetPage",
			"type": "POST",
			"datatype": "json"
		},
		"columnDefs": [],
		"columns": [

			/*{ "data": "id", "name": "id", "autoWidth": true },*/
			/*{ "data": "name", "name": "description", "autoWidth": true },*/
			{
				"data": function(data, row) {
					if (data.room.name === null) return "unassigned";
					return data.room.name;

				},
				"name": "name",
				"autoWidth": true
			},

			{
				"data": function (data, row) {
					return `
                     <div class="dropdown dropdown-inline">
						<a href = "javascript:;" class="btn btn-sm btn-clean btn-icon mr-2" data-toggle="dropdown" >
							<span class="svg-icon svg-icon-md">
								<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">
						<g stroke = "none" stroke - width="1" fill = "none" fill - rule="evenodd" >
										<rect x="0" y="0" width="24" height="24"></rect>
										<path d="M5,8.6862915 L5,5 L8.6862915,5 L11.5857864,2.10050506 L14.4852814,5 L19,5 L19,9.51471863 L21.4852814,12 L19,14.4852814 L19,19 L14.4852814,19 L11.5857864,21.8994949 L8.6862915,19 L5,19 L5,15.3137085 L1.6862915,12 L5,8.6862915 Z M12,15 C13.6568542,15 15,13.6568542 15,12 C15,10.3431458 13.6568542,9 12,9 C10.3431458,9 9,10.3431458 9,12 C9,13.6568542 10.3431458,15 12,15 Z" fill="#000000"></path>
									</g>
								</svg>
							</span>	
						</a >
						<div class="dropdown-menu dropdown-menu-sm dropdown-menu-right">
							<ul class="navi flex-column navi-hover py-2">
								<li class="navi-header font-weight-bolder text-uppercase font-size-xs text-primary pb-2"> Choose an action:  </li>
						<li class="navi-item" >
									<a href="#" data-toggle="modal" data-target="#kt_modal_1_2" class="navi-link">
										<span class="navi-icon"><i class="kt-nav__link-icon flaticon2-expand"></i></span>
										<span class="navi-text details" id="${ data.id }">Update</span>
									</a>
								</li>
								<li class="navi-item">
									<a href="#" data-toggle="modal" data-target="#kt_modal_Add" class="navi-link">
										<span class="navi-icon"><i class="kt-nav__link-icon flaticon2-edit"></i></span>
										<span class="navi-text edit" id="${data.id}">Delete</span>
									</a>
								</li>
								
							</ul>
						</div>
				 </div>`;
				},
			},


		]

	});
}


$(document).ready(function () {
	loadData();
	$(document).keypress(function (e) {
		if (e.which === 13) {
			loadData();
		}
	});

});

