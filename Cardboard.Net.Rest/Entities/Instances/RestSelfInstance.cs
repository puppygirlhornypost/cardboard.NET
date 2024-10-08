using System.Collections.Immutable;
using Cardboard.Instances;
using Cardboard.Users;

using ModelMeta = Cardboard.Net.Rest.API.Meta;
using ModelAdminMeta = Cardboard.Net.Rest.API.AdminMeta;

namespace Cardboard.Rest.Instances;

public class RestSelfInstance : RestEntity<string>, ISelfInstance, IUpdateable
{
    public RestInstanceActor InstanceActor { get; private set; }
    public Meta Meta { get; private set; }
    public AdminMeta? AdminMeta { get; private set; }
    
    public RestSelfInstance(BaseMisskeyClient misskey, string id) : base(misskey, id) { }

    internal static RestSelfInstance Create(BaseMisskeyClient client, ModelMeta model, RestInstanceActor actor)
    {
        RestSelfInstance entity = new(client, actor.Id);
        entity.InstanceActor = actor;
        entity.Update(model);
        return entity;
    }

    internal void Update(ModelMeta model)
    {
        Meta meta = new Meta()
        {
            MaintainerName = model.MaintainerName,
            MaintainerEmail = model.MaintainerEmail,
            Version = model.Version,
            ProvidesTarball = model.ProvidesTarball,
            Name = model.Name,
            ShortName = model.ShortName,
            Url = model.Url,
            Description = model.Description,
            langs = (model.Langs != null && model.Langs.Length != 0) 
                ? ImmutableArray.Create<string>(model.Langs) 
                : ImmutableArray<string>.Empty,
            DefaultDarkTheme = model.DefaultDarkTheme,
            DefaultLightTheme = model.DefaultLightTheme,
            DefaultLike = model.DefaultLike,
            RegistrationDisabled = model.RegistrationDisabled,
            SignupEmailRequired = model.SignupEmailRequired,
            SignupApprovalRequired = model.SignupApprovalRequired,
            CaptchaProviders = new CaptchaProviders()
            {
                EnableHCaptcha = model.EnableHCaptcha,
                HCaptchaSiteKey = model.HCaptchaSiteKey,
                EnableMCaptcha = model.EnableMCaptcha,
                MCaptchaSiteKey = model.MCaptchaSiteKey,
                MCaptchaInstanceUrl = model.MCaptchaInstanceUrl,
                EnableReCaptcha = model.EnableReCaptcha,
                ReCaptchaSiteKey = model.ReCaptchaSiteKey,
                EnableTurnstile = model.EnableTurnstile,
                TurnstileSiteKey = model.TurnstileSiteKey
            },
            InstanceUrls = new InstanceUrls()
            {
                TosUrl = model.TosUrl,
                RepositoryUrl = model.RepositoryUrl,
                FeedbackUrl = model.FeedbackUrl,
                DonationUrl = model.DonationUrl,
                MascotImageUrl = model.MascotImageUrl,
                BannerUrl = model.BannerUrl,
                ServerErrorImageUrl = model.ServerErrorImageUrl,
                InfoImageUrl = model.InfoImageUrl,
                NotFoundImageUrl = model.NotFoundImageUrl,
                IconUrl = model.IconUrl,
                BackgroundImageUrl = model.BackgroundImageUrl,
                ImpressumUrl = model.ImpressumUrl,
                LogoImageUrl = model.LogoImageUrl,
                PrivacyPolicyUrl = model.PrivacyPolicyUrl,
                InquiryUrl = model.InquiryUrl
            },
            EnableAchievements = model.EnableAchievements,
            SwPublicKey = model.SwPublicKey,
            MaxNoteLength = model.MaxNoteLength,
            NotesPerAd = model.NotesPerAd,
            EnableEmail = model.EnableEmail,
            EnableServiceWorker = model.EnableServiceWorker,
            TranslatorAvailable = model.TranslatorAvailable,
            MediaProxy = model.MediaProxy,
            rules = (model.Rules != null && model.Rules.Length != 0) 
                ? ImmutableArray.Create<string>(model.Rules) 
                : ImmutableArray<string>.Empty,
            ThemeColor = model.ThemeColor
        };
        
        Meta = meta;
    }

    internal void Update(ModelAdminMeta model)
    {
        AdminMeta meta = new AdminMeta()
        {
            silencedHosts = (model.SilencedHosts != null && model.SilencedHosts.Length != 0) 
                ? ImmutableArray.Create<string>(model.SilencedHosts)
                : ImmutableArray<string>.Empty,
            pinnedUsers = (model.PinnedUsers != null && model.PinnedUsers.Length != 0) 
                ? ImmutableArray.Create<string>(model.PinnedUsers)
                : ImmutableArray<string>.Empty,
            hiddenTags = (model.HiddenTags != null && model.HiddenTags.Length != 0) 
                ? ImmutableArray.Create<string>(model.HiddenTags)
                : ImmutableArray<string>.Empty,
            blockedHosts = (model.BlockedHosts != null && model.BlockedHosts.Length != 0) 
                ? ImmutableArray.Create<string>(model.BlockedHosts)
                : ImmutableArray<string>.Empty,
            sensitiveWords = (model.SensitiveWords != null && model.SensitiveWords.Length != 0) 
                ? ImmutableArray.Create<string>(model.SensitiveWords)
                : ImmutableArray<string>.Empty,
            prohibitedWords = (model.ProhibitedWords != null && model.ProhibitedWords.Length != 0) 
                ? ImmutableArray.Create<string>(model.ProhibitedWords)
                : ImmutableArray<string>.Empty,
            bannedEmailDomains = (model.BannedEmailDomains != null && model.BannedEmailDomains.Length != 0) 
                ? ImmutableArray.Create<string>(model.BannedEmailDomains)
                : ImmutableArray<string>.Empty,
            preservedUsernames = (model.PreservedUsernames != null && model.PreservedUsernames.Length != 0) 
                ? ImmutableArray.Create<string>(model.PreservedUsernames)
                : ImmutableArray<string>.Empty,
            bubbleInstances = (model.BubbleInstances != null && model.BubbleInstances.Length != 0) 
                ? ImmutableArray.Create<string>(model.BubbleInstances)
                : ImmutableArray<string>.Empty,
            MaintainerName = model.MaintainerName,
            MaintainerEmail = model.MaintainerEmail,
            Version = model.Version,
            Name = model.Name,
            ShortName = model.ShortName,
            Description = model.Description,
            DefaultDarkTheme = model.DefaultDarkTheme,
            DefaultLightTheme = model.DefaultLightTheme,
            SignupEmailRequired = model.SignupEmailRequired,
            SignupApprovalRequired = model.SignupApprovalRequired,
            CaptchaProviders = new AdminCaptchaProviders()
            {
                EnableHCaptcha = model.EnableHCaptcha,
                HCaptchaSiteKey = model.HCaptchaSiteKey,
                HCaptchaSecretKey = model.HCaptchaSecretKey,
                EnableMCaptcha = model.EnableMCaptcha,
                MCaptchaSiteKey = model.MCaptchaSiteKey,
                MCaptchaInstanceUrl = model.MCaptchaInstanceUrl,
                MCaptchaSecretKey = model.MCaptchaSecretKey,
                EnableReCaptcha = model.EnableReCaptcha,
                ReCaptchaSiteKey = model.ReCaptchaSiteKey,
                ReCaptchaSecretKey = model.ReCaptchaSecretKey,
                EnableTurnstile = model.EnableTurnstile,
                TurnstileSiteKey = model.TurnstileSiteKey,
                TurnstileSecretKey = model.TurnstileSecretKey
            },
            InstanceUrls = new AdminInstanceUrls()
            {
                TosUrl = model.TosUrl,
                RepositoryUrl = model.RepositoryUrl,
                DonationUrl = model.DonationUrl,
                MascotImageUrl = model.MascotImageUrl,
                BannerUrl = model.BannerUrl,
                ServerErrorImageUrl = model.ServerErrorImageUrl,
                InfoImageUrl = model.InfoImageUrl,
                NotFoundImageUrl = model.NotFoundImageUrl,
                IconUrl = model.IconUrl,
                BackgroundImageUrl = model.BackgroundImageUrl,
                ImpressumUrl = model.ImpressumUrl,
                PrivacyPolicyUrl = model.PrivacyPolicyUrl,
                InquiryUrl = model.InquiryUrl
            },
            EnableAchievements = model.EnableAchievements,
            EnableEmail = model.EnableEmail,
            EnableServiceWorker = model.EnableServiceWorker,
            TranslatorAvailable = model.TranslatorAvailable,
            ThemeColor = model.ThemeColor
        };
        
        AdminMeta = meta;
    }
    
    public async Task UpdateAsync()
    {
        var model = await Misskey.ApiClient.GetMetaAsync();

        if (model == null)
            return;
        
        Update(model);
    }

    public async Task ModifyAsync(Action<InstanceProperties> func)
    {
        bool success = await InstanceHelper.ModifyMetaAsync(Misskey, func);

        if (!success)
            return;

        await UpdateAsync();
        await GetAdminMetaAsync();
    }

    public async Task<AdminMeta> GetAdminMetaAsync()
    {
        var model = await Misskey.ApiClient.GetAdminMetaAsync();

        if (model == null)
            throw new InvalidOperationException("You are not authorized to fetch admin meta");
        
        Update(model);
        return AdminMeta!;
    }
    
    public async Task<RestFederatedInstance?> GetFederatedInstanceAsync(string host)
        => await InstanceHelper.GetFederatedInstanceAsync(Misskey, host);

    public async Task<IReadOnlyList<RestFederatedInstance>> GetFederatedInstancesAsync
    (
        string? host = null,
        bool? blocked = null,
        bool? notResponding = null,
        bool? suspended = null,
        bool? silenced = null,
        bool? federating = null,
        bool? subscribing = null,
        bool? publishing = null,
        bool? nsfw = null,
        bool? bubble = null,
        int? limit = null,
        int? offset = null,
        InstanceSortType? sort = null
    )
        => await InstanceHelper.GetFederatedInstancesAsync(Misskey, host, blocked, notResponding, suspended, silenced, federating, subscribing, publishing, nsfw, bubble, limit, offset, sort);

    public async Task SilenceInstanceAsync(IFederatedInstance instance)
        => await SilenceInstanceAsync(instance.Host.Host);

    public async Task SilenceInstanceAsync(string host)
    {
        await GetAdminMetaAsync();

        if (AdminMeta!.SilencedHosts.Contains(host))
            throw new InvalidOperationException("Can't silence an already silenced instance");
        
        await ModifyAsync(x => x.SilencedHosts = AdminMeta!.SilencedHosts.Append(host).ToArray());
    }

    public async Task UnsilenceInstanceAsync(IFederatedInstance instance)
        => await UnsilenceInstanceAsync(instance.Host.Host);
    
    public async Task UnsilenceInstanceAsync(string host)
    {
        await GetAdminMetaAsync();

        if (!AdminMeta!.SilencedHosts.Contains(host))
            throw new InvalidOperationException("Can't unsilence an already unsilenced instance");
        
        await ModifyAsync(x => x.SilencedHosts = AdminMeta!.SilencedHosts.Where(x => x != host).ToArray());
    }
    
    public Task GetOnlineUsersCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetServerInfoAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetStatsAsync()
    {
        throw new NotImplementedException();
    }

    public Task PingAsync()
    {
        throw new NotImplementedException();
    }

    IUser ISelfInstance.InstanceActor => InstanceActor;
    IMeta ISelfInstance.Meta => Meta;
}