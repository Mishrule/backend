﻿using System;

namespace GaSchedule.Algorithm
{
    public interface Chromosome<T> where T : Chromosome<T>
    {
        public T MakeNewFromPrototype();

        public float Fitness { get; }

        public Configuration Configuration { get; }

        public T Crossover(T mother, int numberOfCrossoverPoints, float crossoverProbability);
		
		public T Crossover(T parent, T r1, T r2, T r3, float etaCross, float crossoverProbability);

        public void Mutation(int mutationSize, float mutationProbability);

        public float Diversity { get; set; }

        public int Rank { get; set; }

    }
}
