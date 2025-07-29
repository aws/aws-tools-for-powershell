/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Creates an API key resource in your Amazon Web Services account, which lets you grant
    /// actions for Amazon Location resources to the API key bearer.
    /// 
    ///  <note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/location/previous/developerguide/using-apikeys.html">Using
    /// API keys</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "LOCKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.CreateKeyResponse")]
    [AWSCmdlet("Calls the Amazon Location Service CreateKey API operation.", Operation = new[] {"CreateKey"}, SelectReturnType = typeof(Amazon.LocationService.Model.CreateKeyResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.CreateKeyResponse",
        "This cmdlet returns an Amazon.LocationService.Model.CreateKeyResponse object containing multiple properties."
    )]
    public partial class NewLOCKeyCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Restrictions_AllowAction
        /// <summary>
        /// <para>
        /// <para>A list of allowed actions that an API key resource grants permissions to perform.
        /// You must have at least one action for each type of resource. For example, if you have
        /// a place resource, you must include at least one place action.</para><para>The following are valid values for the actions.</para><ul><li><para><b>Map actions</b></para><ul><li><para><c>geo:GetMap*</c> - Allows all actions needed for map rendering.</para></li><li><para><c>geo-maps:GetTile</c> - Allows retrieving map tiles.</para></li><li><para><c>geo-maps:GetStaticMap</c> - Allows retrieving static map images.</para></li><li><para><c>geo-maps:*</c> - Allows all actions related to map functionalities.</para></li></ul></li><li><para><b>Place actions</b></para><ul><li><para><c>geo:SearchPlaceIndexForText</c> - Allows geocoding.</para></li><li><para><c>geo:SearchPlaceIndexForPosition</c> - Allows reverse geocoding.</para></li><li><para><c>geo:SearchPlaceIndexForSuggestions</c> - Allows generating suggestions from text.</para></li><li><para><c>GetPlace</c> - Allows finding a place by place ID.</para></li><li><para><c>geo-places:Geocode</c> - Allows geocoding using place information.</para></li><li><para><c>geo-places:ReverseGeocode</c> - Allows reverse geocoding from location coordinates.</para></li><li><para><c>geo-places:SearchNearby</c> - Allows searching for places near a location.</para></li><li><para><c>geo-places:SearchText</c> - Allows searching for places based on text input.</para></li><li><para><c>geo-places:Autocomplete</c> - Allows auto-completion of place names based on text
        /// input.</para></li><li><para><c>geo-places:Suggest</c> - Allows generating suggestions for places based on partial
        /// input.</para></li><li><para><c>geo-places:GetPlace</c> - Allows finding a place by its ID.</para></li><li><para><c>geo-places:*</c> - Allows all actions related to place services.</para></li></ul></li><li><para><b>Route actions</b></para><ul><li><para><c>geo:CalculateRoute</c> - Allows point to point routing.</para></li><li><para><c>geo:CalculateRouteMatrix</c> - Allows calculating a matrix of routes.</para></li><li><para><c>geo-routes:CalculateRoutes</c> - Allows calculating multiple routes between points.</para></li><li><para><c>geo-routes:CalculateRouteMatrix</c> - Allows calculating a matrix of routes between
        /// points.</para></li><li><para><c>geo-routes:CalculateIsolines</c> - Allows calculating isolines for a given area.</para></li><li><para><c>geo-routes:OptimizeWaypoints</c> - Allows optimizing the order of waypoints in
        /// a route.</para></li><li><para><c>geo-routes:SnapToRoads</c> - Allows snapping a route to the nearest roads.</para></li><li><para><c>geo-routes:*</c> - Allows all actions related to routing functionalities.</para></li></ul></li></ul><note><para>You must use these strings exactly. For example, to provide access to map rendering,
        /// the only valid action is <c>geo:GetMap*</c> as an input to the list. <c>["geo:GetMap*"]</c>
        /// is valid but <c>["geo:GetMapTile"]</c> is not. Similarly, you cannot use <c>["geo:SearchPlaceIndexFor*"]</c>
        /// - you must list each of the Place actions separately.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Restrictions_AllowActions")]
        public System.String[] Restrictions_AllowAction { get; set; }
        #endregion
        
        #region Parameter Restrictions_AllowReferer
        /// <summary>
        /// <para>
        /// <para>An optional list of allowed HTTP referers for which requests must originate from.
        /// Requests using this API key from other domains will not be allowed.</para><para>Requirements:</para><ul><li><para>Contain only alphanumeric characters (A–Z, a–z, 0–9) or any symbols in this list <c>$\-._+!*`(),;/?:@=&amp;</c></para></li><li><para>May contain a percent (%) if followed by 2 hexadecimal digits (A-F, a-f, 0-9); this
        /// is used for URL encoding purposes.</para></li><li><para>May contain wildcard characters question mark (?) and asterisk (*).</para><para>Question mark (?) will replace any single character (including hexadecimal digits).</para><para>Asterisk (*) will replace any multiple characters (including multiple hexadecimal
        /// digits).</para></li><li><para>No spaces allowed. For example, <c>https://example.com</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Restrictions_AllowReferers")]
        public System.String[] Restrictions_AllowReferer { get; set; }
        #endregion
        
        #region Parameter Restrictions_AllowResource
        /// <summary>
        /// <para>
        /// <para>A list of allowed resource ARNs that a API key bearer can perform actions on.</para><ul><li><para>The ARN must be the correct ARN for a map, place, or route ARN. You may include wildcards
        /// in the resource-id to match multiple resources of the same type.</para></li><li><para>The resources must be in the same <c>partition</c>, <c>region</c>, and <c>account-id</c>
        /// as the key that is being created.</para></li><li><para>Other than wildcards, you must include the full ARN, including the <c>arn</c>, <c>partition</c>,
        /// <c>service</c>, <c>region</c>, <c>account-id</c> and <c>resource-id</c> delimited
        /// by colons (:).</para></li><li><para>No spaces allowed, even with wildcards. For example, <c>arn:aws:geo:region:<i>account-id</i>:map/ExampleMap*</c>.</para></li></ul><para>For more information about ARN format, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Restrictions_AllowResources")]
        public System.String[] Restrictions_AllowResource { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the API key resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExpireTime
        /// <summary>
        /// <para>
        /// <para>The optional timestamp for when the API key resource will expire in <a href="https://www.iso.org/iso-8601-date-and-time-format.html">
        /// ISO 8601</a> format: <c>YYYY-MM-DDThh:mm:ss.sssZ</c>. One of <c>NoExpiry</c> or <c>ExpireTime</c>
        /// must be set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpireTime { get; set; }
        #endregion
        
        #region Parameter KeyName
        /// <summary>
        /// <para>
        /// <para>A custom name for the API key resource.</para><para>Requirements:</para><ul><li><para>Contain only alphanumeric characters (A–Z, a–z, 0–9), hyphens (-), periods (.), and
        /// underscores (_). </para></li><li><para>Must be a unique API key name.</para></li><li><para>No spaces allowed. For example, <c>ExampleAPIKey</c>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String KeyName { get; set; }
        #endregion
        
        #region Parameter NoExpiry
        /// <summary>
        /// <para>
        /// <para>Optionally set to <c>true</c> to set no expiration time for the API key. One of <c>NoExpiry</c>
        /// or <c>ExpireTime</c> must be set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NoExpiry { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Applies one or more tags to the map resource. A tag is a key-value pair that helps
        /// manage, identify, search, and filter your resources by labelling them.</para><para>Format: <c>"key" : "value"</c></para><para>Restrictions:</para><ul><li><para>Maximum 50 tags per resource</para></li><li><para>Each resource tag must be unique with a maximum of one value.</para></li><li><para>Maximum key length: 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length: 256 Unicode characters in UTF-8</para></li><li><para>Can use alphanumeric characters (A–Z, a–z, 0–9), and the following characters: + -
        /// = . _ : / @. </para></li><li><para>Cannot use "aws:" as a prefix for a key.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.CreateKeyResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.CreateKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LOCKey (CreateKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.CreateKeyResponse, NewLOCKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.ExpireTime = this.ExpireTime;
            context.KeyName = this.KeyName;
            #if MODULAR
            if (this.KeyName == null && ParameterWasBound(nameof(this.KeyName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NoExpiry = this.NoExpiry;
            if (this.Restrictions_AllowAction != null)
            {
                context.Restrictions_AllowAction = new List<System.String>(this.Restrictions_AllowAction);
            }
            #if MODULAR
            if (this.Restrictions_AllowAction == null && ParameterWasBound(nameof(this.Restrictions_AllowAction)))
            {
                WriteWarning("You are passing $null as a value for parameter Restrictions_AllowAction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Restrictions_AllowReferer != null)
            {
                context.Restrictions_AllowReferer = new List<System.String>(this.Restrictions_AllowReferer);
            }
            if (this.Restrictions_AllowResource != null)
            {
                context.Restrictions_AllowResource = new List<System.String>(this.Restrictions_AllowResource);
            }
            #if MODULAR
            if (this.Restrictions_AllowResource == null && ParameterWasBound(nameof(this.Restrictions_AllowResource)))
            {
                WriteWarning("You are passing $null as a value for parameter Restrictions_AllowResource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.LocationService.Model.CreateKeyRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExpireTime != null)
            {
                request.ExpireTime = cmdletContext.ExpireTime.Value;
            }
            if (cmdletContext.KeyName != null)
            {
                request.KeyName = cmdletContext.KeyName;
            }
            if (cmdletContext.NoExpiry != null)
            {
                request.NoExpiry = cmdletContext.NoExpiry.Value;
            }
            
             // populate Restrictions
            var requestRestrictionsIsNull = true;
            request.Restrictions = new Amazon.LocationService.Model.ApiKeyRestrictions();
            List<System.String> requestRestrictions_restrictions_AllowAction = null;
            if (cmdletContext.Restrictions_AllowAction != null)
            {
                requestRestrictions_restrictions_AllowAction = cmdletContext.Restrictions_AllowAction;
            }
            if (requestRestrictions_restrictions_AllowAction != null)
            {
                request.Restrictions.AllowActions = requestRestrictions_restrictions_AllowAction;
                requestRestrictionsIsNull = false;
            }
            List<System.String> requestRestrictions_restrictions_AllowReferer = null;
            if (cmdletContext.Restrictions_AllowReferer != null)
            {
                requestRestrictions_restrictions_AllowReferer = cmdletContext.Restrictions_AllowReferer;
            }
            if (requestRestrictions_restrictions_AllowReferer != null)
            {
                request.Restrictions.AllowReferers = requestRestrictions_restrictions_AllowReferer;
                requestRestrictionsIsNull = false;
            }
            List<System.String> requestRestrictions_restrictions_AllowResource = null;
            if (cmdletContext.Restrictions_AllowResource != null)
            {
                requestRestrictions_restrictions_AllowResource = cmdletContext.Restrictions_AllowResource;
            }
            if (requestRestrictions_restrictions_AllowResource != null)
            {
                request.Restrictions.AllowResources = requestRestrictions_restrictions_AllowResource;
                requestRestrictionsIsNull = false;
            }
             // determine if request.Restrictions should be set to null
            if (requestRestrictionsIsNull)
            {
                request.Restrictions = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LocationService.Model.CreateKeyResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.CreateKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "CreateKey");
            try
            {
                #if DESKTOP
                return client.CreateKey(request);
                #elif CORECLR
                return client.CreateKeyAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Description { get; set; }
            public System.DateTime? ExpireTime { get; set; }
            public System.String KeyName { get; set; }
            public System.Boolean? NoExpiry { get; set; }
            public List<System.String> Restrictions_AllowAction { get; set; }
            public List<System.String> Restrictions_AllowReferer { get; set; }
            public List<System.String> Restrictions_AllowResource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LocationService.Model.CreateKeyResponse, NewLOCKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
