using System;
using IModel;
using Services;
using Entities;

namespace Presentation {
    class MainClass {
        static void Main(string[] args) {
            IBegining beginingSevise = new BeginingService();
            beginingSevise.Begin(new BeginningConfiguration(5,1));
        }
    }
}
