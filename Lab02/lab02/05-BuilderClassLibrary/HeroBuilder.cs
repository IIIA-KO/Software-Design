﻿using _05_BuilderClassLibrary.Interfaces;

namespace _05_BuilderClassLibrary
{
    // Step-wise builder with optional parameters:
    internal class HeroBuilder : IHeroBuilder
    {
        private string Name { get; set; }
        private string Outfit { get; set; }
        private double Height { get; set; }
        private string Build { get; set; }
        private string HairColor { get; set; }
        private string EyeColor { get; set; }

        private HeroBuilder()
        {
            this.Name = string.Empty;
            this.Outfit = string.Empty;
            this.Height = 0;
            this.HairColor = "Hair color is not provided";
            this.EyeColor = "Eye color is not provided";
            this.Build = "Build is not provided";
        }

        private static string GetErrorMessage(string paramName)
        {
            return $"Cannot build a hero. Invalid {paramName} provided.";
        }

        public static IExpectsOutfit WithName(string name) =>
            new HeroBuilder() { Name = ValidName(name) };

        private static string ValidName(string name)
        {
            return !string.IsNullOrEmpty(name)
                ? name
                : throw new ArgumentException(GetErrorMessage(nameof(name)), nameof(name));
        }

        public IExpectsBodyParameters InOutfit(string outfit)
        {
            this.Outfit = ValidOutfit(outfit);
            return this;
        }

        private static string ValidOutfit(string outfit)
        {
            return !string.IsNullOrEmpty(outfit)
                ? outfit
                : throw new ArgumentException(GetErrorMessage(nameof(outfit)), nameof(outfit));
        }

        public IExpectsBodyParameters WithHeight(double height)
        {
            this.Height = ValidHeight(height);
            return this;
        }

        private static double ValidHeight(double height)
        {
            return height > 0
                ? height
                : throw new ArgumentOutOfRangeException(nameof(height), GetErrorMessage(nameof(height)));
        }

        public IExpectsBodyParameters WithHairColor(string hairColor)
        {
            this.HairColor = ValidBodyParameter(hairColor);
            return this;
        }

        public IExpectsBodyParameters WithEyeColor(string eyeColor)
        {
            this.EyeColor = ValidBodyParameter(eyeColor);
            return this;
        }

        public IExpectsBodyParameters WithBuild(string build)
        {
            this.Build = ValidBodyParameter(build);
            return this;
        }

        private static string ValidBodyParameter(string bodyParameter)
        {
            return !string.IsNullOrEmpty(bodyParameter)
                ? bodyParameter
                : throw new ArgumentException(GetErrorMessage(nameof(bodyParameter)), nameof(bodyParameter));
        }

        public Hero Create()
        {
            return new Hero
            {
                Name = this.Name,
                Outfit = this.Outfit,
                Height = this.Height,
                HairColor = this.HairColor,
                EyeColor = this.EyeColor,
                Build = this.Build
            };
        }
    }
}