namespace Runtime.Domain
{
    public static class TraitRelationshipToHappiness
    {
        public static int ToPreviewHappiness(this Trait.Relationship what) => (int)what;
    };
}