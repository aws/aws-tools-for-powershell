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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates presigned URLs for accessing hub content artifacts. This operation generates
    /// time-limited, secure URLs that allow direct download of model artifacts and associated
    /// files from Amazon SageMaker hub content, including gated models that require end-user
    /// license agreement acceptance.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("New", "SMHubContentPresignedUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.AuthorizedUrl")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateHubContentPresignedUrls API operation.", Operation = new[] {"CreateHubContentPresignedUrls"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.AuthorizedUrl or Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.AuthorizedUrl objects.",
        "The service call response (type Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMHubContentPresignedUrlCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessConfig_AcceptEula
        /// <summary>
        /// <para>
        /// <para>Indicates acceptance of the End User License Agreement (EULA) for gated models. Set
        /// to true to acknowledge acceptance of the license terms required for accessing gated
        /// content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccessConfig_AcceptEula { get; set; }
        #endregion
        
        #region Parameter AccessConfig_ExpectedS3Url
        /// <summary>
        /// <para>
        /// <para>The expected S3 URL prefix for validation purposes. This parameter helps ensure consistency
        /// between the resolved S3 URIs and the deployment configuration, reducing potential
        /// compatibility issues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessConfig_ExpectedS3Url { get; set; }
        #endregion
        
        #region Parameter HubContentName
        /// <summary>
        /// <para>
        /// <para>The name of the hub content for which to generate presigned URLs. This identifies
        /// the specific model or content within the hub.</para>
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
        public System.String HubContentName { get; set; }
        #endregion
        
        #region Parameter HubContentType
        /// <summary>
        /// <para>
        /// <para>The type of hub content to access. Valid values include <c>Model</c>, <c>Notebook</c>,
        /// and <c>ModelReference</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.HubContentType")]
        public Amazon.SageMaker.HubContentType HubContentType { get; set; }
        #endregion
        
        #region Parameter HubContentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the hub content. If not specified, the latest version is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HubContentVersion { get; set; }
        #endregion
        
        #region Parameter HubName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the hub that contains the content. For public
        /// content, use <c>SageMakerPublicHub</c>.</para>
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
        public System.String HubName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of presigned URLs to return in the response. Default value is 100.
        /// Large models may contain hundreds of files, requiring pagination to retrieve all URLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A token for pagination. Use this token to retrieve the next set of presigned URLs
        /// when the response is truncated.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthorizedUrlConfigs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthorizedUrlConfigs";
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
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HubContentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMHubContentPresignedUrl (CreateHubContentPresignedUrls)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse, NewSMHubContentPresignedUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessConfig_AcceptEula = this.AccessConfig_AcceptEula;
            context.AccessConfig_ExpectedS3Url = this.AccessConfig_ExpectedS3Url;
            context.HubContentName = this.HubContentName;
            #if MODULAR
            if (this.HubContentName == null && ParameterWasBound(nameof(this.HubContentName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubContentType = this.HubContentType;
            #if MODULAR
            if (this.HubContentType == null && ParameterWasBound(nameof(this.HubContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter HubContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HubContentVersion = this.HubContentVersion;
            context.HubName = this.HubName;
            #if MODULAR
            if (this.HubName == null && ParameterWasBound(nameof(this.HubName)))
            {
                WriteWarning("You are passing $null as a value for parameter HubName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.CreateHubContentPresignedUrlsRequest();
            
            
             // populate AccessConfig
            var requestAccessConfigIsNull = true;
            request.AccessConfig = new Amazon.SageMaker.Model.PresignedUrlAccessConfig();
            System.Boolean? requestAccessConfig_accessConfig_AcceptEula = null;
            if (cmdletContext.AccessConfig_AcceptEula != null)
            {
                requestAccessConfig_accessConfig_AcceptEula = cmdletContext.AccessConfig_AcceptEula.Value;
            }
            if (requestAccessConfig_accessConfig_AcceptEula != null)
            {
                request.AccessConfig.AcceptEula = requestAccessConfig_accessConfig_AcceptEula.Value;
                requestAccessConfigIsNull = false;
            }
            System.String requestAccessConfig_accessConfig_ExpectedS3Url = null;
            if (cmdletContext.AccessConfig_ExpectedS3Url != null)
            {
                requestAccessConfig_accessConfig_ExpectedS3Url = cmdletContext.AccessConfig_ExpectedS3Url;
            }
            if (requestAccessConfig_accessConfig_ExpectedS3Url != null)
            {
                request.AccessConfig.ExpectedS3Url = requestAccessConfig_accessConfig_ExpectedS3Url;
                requestAccessConfigIsNull = false;
            }
             // determine if request.AccessConfig should be set to null
            if (requestAccessConfigIsNull)
            {
                request.AccessConfig = null;
            }
            if (cmdletContext.HubContentName != null)
            {
                request.HubContentName = cmdletContext.HubContentName;
            }
            if (cmdletContext.HubContentType != null)
            {
                request.HubContentType = cmdletContext.HubContentType;
            }
            if (cmdletContext.HubContentVersion != null)
            {
                request.HubContentVersion = cmdletContext.HubContentVersion;
            }
            if (cmdletContext.HubName != null)
            {
                request.HubName = cmdletContext.HubName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateHubContentPresignedUrlsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateHubContentPresignedUrls");
            try
            {
                #if DESKTOP
                return client.CreateHubContentPresignedUrls(request);
                #elif CORECLR
                return client.CreateHubContentPresignedUrlsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AccessConfig_AcceptEula { get; set; }
            public System.String AccessConfig_ExpectedS3Url { get; set; }
            public System.String HubContentName { get; set; }
            public Amazon.SageMaker.HubContentType HubContentType { get; set; }
            public System.String HubContentVersion { get; set; }
            public System.String HubName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateHubContentPresignedUrlsResponse, NewSMHubContentPresignedUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthorizedUrlConfigs;
        }
        
    }
}
