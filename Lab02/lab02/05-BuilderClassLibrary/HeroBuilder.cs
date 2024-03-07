﻿namespace _05_BuilderClassLibrary
{
    public class HeroBuilder : IHeroBuilder
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Outfit { get; set; }

        private HeroBuilder() { }

        public static IExpectsOutfit WithName(string name) =>
            new HeroBuilder() { Name = ValidName(name) };

        private static string ValidName(string name)
        {
            return !string.IsNullOrEmpty(name) 
                ? name
                : throw new ArgumentException("Cannot build a hero. Invalid name provided.", nameof(name));
        }

        public IExpectsBodyParameters InOutfit(string outfit)
        {
            this.Outfit = ValidOutfit(outfit);
            return this;
        }

        private static string ValidOutfit(string outfit)
        {
            return !string.IsNullOrEmpty(outfit) ?
               outfit
               : throw new ArgumentException("Cannot build a hero. Invalid outfit provided.", nameof(outfit));
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
                : throw new ArgumentOutOfRangeException(nameof(height), "Cannot build a hero. Invalid height provided.");
        }

        public IExpectsBodyParameters WithHairColor(string  hairColor)
        {
            this.HairColor = ValidBodyParameter(hairColor);
            return this;
        }

        public IExpectsBodyParameters WithEyeColor(string  eyeColor)
        {
            this.EyeColor = ValidBodyParameter(eyeColor);
            return this;
        }

        public IExpectsBodyParameters WithBuild(string  build)
        {
            this.Build = ValidBodyParameter(build);
            return this;
        }

        private static string ValidBodyParameter(string bodyParameter)
        {
            return !string.IsNullOrEmpty(bodyParameter) ?
                bodyParameter 
                : throw new ArgumentException($"Cannot build a hero. Invalid {nameof(bodyParameter)} provided.", nameof(bodyParameter));
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