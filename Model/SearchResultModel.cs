namespace NetEaseCLI.Model
{
    /// <summary>
    /// 歌曲信息模型
    /// </summary>
    public abstract class SongModel
    {
        /// <summary>歌曲ID</summary>
        public int? Id { get; set; }
        
        /// <summary>歌曲名称</summary>
        public string? Name { get; set; }
        
        /// <summary>歌手列表</summary>
        public List<ArtistModel>? Artists { get; set; } = [];
        
        /// <summary>专辑信息</summary>
        public AlbumModel? Album { get; set; }
        
        /// <summary>歌曲时长(毫秒)</summary>
        public int? Duration { get; set; }
        
        /// <summary>版权ID</summary>
        public int? CopyrightId { get; set; }
        
        /// <summary>状态</summary>
        public int? Status { get; set; }
        
        /// <summary>别名列表</summary>
        public List<string>? Alias { get; set; } = [];
        
        /// <summary>类型</summary>
        public int? Rtype { get; set; }
        
        /// <summary>类型</summary>
        public int? Ftype { get; set; }
        
        /// <summary>MV ID</summary>
        public int? Mvid { get; set; }
        
        /// <summary>费用</summary>
        public int? Fee { get; set; }
        
        /// <summary>音源URL</summary>
        public string? RUrl { get; set; }
        
        /// <summary>标记</summary>
        public int? Mark { get; set; }
    }
    
    /// <summary>
    /// 歌手信息模型
    /// </summary>
    public abstract class ArtistModel
    {
        /// <summary>歌手ID</summary>
        public int? Id { get; set; }
        
        /// <summary>歌手名称</summary>
        public string? Name { get; set; }
        
        /// <summary>歌手图片URL</summary>
        public string? PicUrl { get; set; }
        
        /// <summary>别名列表</summary>
        public List<string>? Alias { get; set; } = new List<string>();
        
        /// <summary>专辑数量</summary>
        public int? AlbumSize { get; set; }
        
        /// <summary>图片ID</summary>
        public int? PicId { get; set; }
        
        /// <summary>粉丝团</summary>
        public object? FansGroup { get; set; }
        
        /// <summary>1v1图片URL</summary>
        public string? Img1V1Url { get; set; }
        
        /// <summary>1v1图片ID</summary>
        public int? Img1V1 { get; set; }
        
        /// <summary>转换</summary>
        public string? Trans { get; set; }
    }
    
    /// <summary>
    /// 专辑信息模型
    /// </summary>
    public abstract class AlbumModel
    {
        /// <summary>专辑ID</summary>
        public int? Id { get; set; }
        
        /// <summary>专辑名称</summary>
        public string? Name { get; set; }
        
        /// <summary>歌手信息</summary>
        public ArtistModel? Artist { get; set; }
        
        /// <summary>发行时间(时间戳)</summary>
        public long? PublishTime { get; set; }
        
        /// <summary>专辑大小</summary>
        public int? Size { get; set; }
        
        /// <summary>版权ID</summary>
        public int? CopyrightId { get; set; }
        
        /// <summary>状态</summary>
        public int? Status { get; set; }
        
        /// <summary>图片ID</summary>
        public int? PicId { get; set; }
        
        /// <summary>标记</summary>
        public int? Mark { get; set; }
    }
}