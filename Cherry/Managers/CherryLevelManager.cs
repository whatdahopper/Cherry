﻿using System.Linq;

namespace Cherry.Managers
{
    internal class CherryLevelManager
    {
        private readonly BeatmapLevelsModel _beatmapLevelsModel;

        public CherryLevelManager(BeatmapLevelsModel beatmapLevelsModel)
        {
            _beatmapLevelsModel = beatmapLevelsModel;
        }

        public bool LevelIsInstalled(string hash)
        {
            string cleanerHash = $"custom_level_{hash.ToUpper()}";
            bool levelExists = _beatmapLevelsModel.allLoadedBeatmapLevelPackCollection.beatmapLevelPacks.Any(bm => bm.beatmapLevelCollection.beatmapLevels.Any(lvl => lvl.levelID == cleanerHash));
            return levelExists;
        }

        public IPreviewBeatmapLevel? TryGetLevel(string hash)
        {
            string cleanerHash = $"custom_level_{hash.ToUpper()}";
            return _beatmapLevelsModel.allLoadedBeatmapLevelPackCollection.beatmapLevelPacks.SelectMany(bm => bm.beatmapLevelCollection.beatmapLevels).FirstOrDefault(lvl => lvl.levelID == cleanerHash);
        }
    }
}