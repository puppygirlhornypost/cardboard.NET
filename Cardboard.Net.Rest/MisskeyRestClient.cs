using Cardboard.Notes;
using Cardboard.Rest;
using Cardboard.Rest.Drives;
using Cardboard.Rest.Notes;

namespace Cardboard.Net.Rest;

public class MisskeyRestClient : BaseMisskeyClient
{
    public new RestSelfUser CurrentUser { get => base.CurrentUser as RestSelfUser; internal set => base.CurrentUser = value; }
    
    public MisskeyRestClient() : this(new MisskeyConfig()) { }
    
    public MisskeyRestClient(MisskeyConfig config) : base(config, CreateApiClient(config))
    {
        
    }

    internal MisskeyRestClient(MisskeyConfig config, MisskeyRestApiClient client) : base(config, client) { }

    internal override async Task OnLoginAsync(string token, Uri baseUrl)
    {
        var user = await ApiClient.GetSelfUserAsync().ConfigureAwait(false);
        Console.WriteLine(user.Name); 
    }
    
    private static MisskeyRestApiClient CreateApiClient(MisskeyConfig config)
        => new MisskeyRestApiClient(MisskeyConfig.UserAgent);
    
    #region Notes

    public async Task<RestNote?> GetNoteAsync(string noteId)
        => await NoteHelper.GetNoteAsync(this, noteId);

    public async Task<RestNote> CreateNoteAsync
    (
        string text,
        string? contentWarning = null,
        bool? localOnly = null,
        AcceptanceType? acceptanceType = null,
        bool? noExtractMentions = null,
        bool? noExtractHashtags = null,
        bool? noExtractEmojis = null,
        VisibilityType? visibilityType = null,
        Poll? poll = null
    )
    {
        RestNote? note = await NoteHelper.CreateNoteAsync
        (
            this, 
            text: text, 
            contentWarning: contentWarning, 
            localOnly: localOnly,
            acceptanceType: acceptanceType,
            noExtractMentions: noExtractMentions,
            noExtractHashtags: noExtractHashtags,
            noExtractEmojis: noExtractEmojis,
            visibilityType: visibilityType,
            poll: poll
        );

        if (note == null)
            throw new InvalidOperationException("unable to create note");

        return note;
    }
    
    #endregion
    
    #region Users
    
    public async Task<RestUser> GetUserAsync(string userId)
        => await ClientHelper.GetUserAsync(this, userId);
    
    public async Task ReportUserAsync(string userId, string comment)
        => await ApiClient.ReportUserAsync(userId, comment);
    
    #endregion
    
    #region Files
    
    public async Task UploadFileAsync(Uri url, string? folderId = null, string? comment = null, string? marker = null,
        bool? isSensitive = false, bool force = false)
        => await ApiClient.UploadFileUriAsync(url, folderId, comment, marker, isSensitive, force);
    
    public async Task<RestDriveFile> GetFileAsync(string fileId)
        => await ClientHelper.GetDriveFileAsync(this, fileId);

    public async Task<RestDriveFile> GetFileAsync(Uri url)
        => await ClientHelper.GetDriveFileAsync(this, url);
    
    #endregion
}