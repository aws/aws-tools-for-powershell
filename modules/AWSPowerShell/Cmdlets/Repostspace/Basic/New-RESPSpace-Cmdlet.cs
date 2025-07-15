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
using System.Threading;
using Amazon.Repostspace;
using Amazon.Repostspace.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RESP
{
    /// <summary>
    /// Creates an AWS re:Post Private private re:Post.
    /// </summary>
    [Cmdlet("New", "RESPSpace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS re:Post Private CreateSpace API operation.", Operation = new[] {"CreateSpace"}, SelectReturnType = typeof(Amazon.Repostspace.Model.CreateSpaceResponse))]
    [AWSCmdletOutput("System.String or Amazon.Repostspace.Model.CreateSpaceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Repostspace.Model.CreateSpaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRESPSpaceCmdlet : AmazonRepostspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SupportedEmailDomains_AllowedDomain
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedEmailDomains_AllowedDomains")]
        public System.String[] SupportedEmailDomains_AllowedDomain { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the private re:Post. This is used only to help you identify this
        /// private re:Post.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SupportedEmailDomains_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Repostspace.FeatureEnableParameter")]
        public Amazon.Repostspace.FeatureEnableParameter SupportedEmailDomains_Enabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the private re:Post. This must be unique in your account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that grants permissions to the private re:Post to convert unanswered
        /// questions into AWS support tickets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Subdomain
        /// <summary>
        /// <para>
        /// <para>The subdomain that you use to access your AWS re:Post Private private re:Post. All
        /// custom subdomains must be approved by AWS before use. In addition to your custom subdomain,
        /// all private re:Posts are issued an AWS generated subdomain for immediate use.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Subdomain { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags associated with the private re:Post.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>The pricing tier for the private re:Post.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Repostspace.TierLevel")]
        public Amazon.Repostspace.TierLevel Tier { get; set; }
        #endregion
        
        #region Parameter UserKMSKey
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key ARN that’s used for the AWS KMS encryption. If you don't provide a
        /// key, your data is encrypted by default with a key that AWS owns and manages for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserKMSKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SpaceId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Repostspace.Model.CreateSpaceResponse).
        /// Specifying the name of a property of type Amazon.Repostspace.Model.CreateSpaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SpaceId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RESPSpace (CreateSpace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Repostspace.Model.CreateSpaceResponse, NewRESPSpaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            context.Subdomain = this.Subdomain;
            #if MODULAR
            if (this.Subdomain == null && ParameterWasBound(nameof(this.Subdomain)))
            {
                WriteWarning("You are passing $null as a value for parameter Subdomain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SupportedEmailDomains_AllowedDomain != null)
            {
                context.SupportedEmailDomains_AllowedDomain = new List<System.String>(this.SupportedEmailDomains_AllowedDomain);
            }
            context.SupportedEmailDomains_Enabled = this.SupportedEmailDomains_Enabled;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Tier = this.Tier;
            #if MODULAR
            if (this.Tier == null && ParameterWasBound(nameof(this.Tier)))
            {
                WriteWarning("You are passing $null as a value for parameter Tier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserKMSKey = this.UserKMSKey;
            
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
            var request = new Amazon.Repostspace.Model.CreateSpaceRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Subdomain != null)
            {
                request.Subdomain = cmdletContext.Subdomain;
            }
            
             // populate SupportedEmailDomains
            var requestSupportedEmailDomainsIsNull = true;
            request.SupportedEmailDomains = new Amazon.Repostspace.Model.SupportedEmailDomainsParameters();
            List<System.String> requestSupportedEmailDomains_supportedEmailDomains_AllowedDomain = null;
            if (cmdletContext.SupportedEmailDomains_AllowedDomain != null)
            {
                requestSupportedEmailDomains_supportedEmailDomains_AllowedDomain = cmdletContext.SupportedEmailDomains_AllowedDomain;
            }
            if (requestSupportedEmailDomains_supportedEmailDomains_AllowedDomain != null)
            {
                request.SupportedEmailDomains.AllowedDomains = requestSupportedEmailDomains_supportedEmailDomains_AllowedDomain;
                requestSupportedEmailDomainsIsNull = false;
            }
            Amazon.Repostspace.FeatureEnableParameter requestSupportedEmailDomains_supportedEmailDomains_Enabled = null;
            if (cmdletContext.SupportedEmailDomains_Enabled != null)
            {
                requestSupportedEmailDomains_supportedEmailDomains_Enabled = cmdletContext.SupportedEmailDomains_Enabled;
            }
            if (requestSupportedEmailDomains_supportedEmailDomains_Enabled != null)
            {
                request.SupportedEmailDomains.Enabled = requestSupportedEmailDomains_supportedEmailDomains_Enabled;
                requestSupportedEmailDomainsIsNull = false;
            }
             // determine if request.SupportedEmailDomains should be set to null
            if (requestSupportedEmailDomainsIsNull)
            {
                request.SupportedEmailDomains = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
            }
            if (cmdletContext.UserKMSKey != null)
            {
                request.UserKMSKey = cmdletContext.UserKMSKey;
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
        
        private Amazon.Repostspace.Model.CreateSpaceResponse CallAWSServiceOperation(IAmazonRepostspace client, Amazon.Repostspace.Model.CreateSpaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS re:Post Private", "CreateSpace");
            try
            {
                return client.CreateSpaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.String Subdomain { get; set; }
            public List<System.String> SupportedEmailDomains_AllowedDomain { get; set; }
            public Amazon.Repostspace.FeatureEnableParameter SupportedEmailDomains_Enabled { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Repostspace.TierLevel Tier { get; set; }
            public System.String UserKMSKey { get; set; }
            public System.Func<Amazon.Repostspace.Model.CreateSpaceResponse, NewRESPSpaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SpaceId;
        }
        
    }
}
