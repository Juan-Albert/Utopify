namespace Runtime.Domain
{
    public static class TraitRelationshipToHappiness
    {
        public static int ToPreviewHappiness(this Trait.Affinity what) => (int)what;
    };
}