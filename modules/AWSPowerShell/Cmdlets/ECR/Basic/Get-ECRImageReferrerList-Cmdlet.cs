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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Lists the artifacts associated with a specified subject image.
    /// 
    ///  <note><para>
    /// The IAM principal invoking this operation must have the <c>ecr:BatchGetImage</c> permission.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "ECRImageReferrerList")]
    [OutputType("Amazon.ECR.Model.ImageReferrer")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry ListImageReferrers API operation.", Operation = new[] {"ListImageReferrers"}, SelectReturnType = typeof(Amazon.ECR.Model.ListImageReferrersResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.ImageReferrer or Amazon.ECR.Model.ListImageReferrersResponse",
        "This cmdlet returns a collection of Amazon.ECR.Model.ImageReferrer objects.",
        "The service call response (type Amazon.ECR.Model.ListImageReferrersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECRImageReferrerListCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter_ArtifactStatus
        /// <summary>
        /// <para>
        /// <para>The artifact status with which to filter your <a>ListImageReferrers</a> results. Valid
        /// values are <c>ACTIVE</c>, <c>ARCHIVED</c>, <c>ACTIVATING</c>, or <c>ANY</c>. If not
        /// specified, only artifacts with <c>ACTIVE</c> status are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECR.ArtifactStatusFilter")]
        public Amazon.ECR.ArtifactStatusFilter Filter_ArtifactStatus { get; set; }
        #endregion
        
        #region Parameter Filter_ArtifactType
        /// <summary>
        /// <para>
        /// <para>The artifact types with which to filter your <a>ListImageReferrers</a> results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ArtifactTypes")]
        public System.String[] Filter_ArtifactType { get; set; }
        #endregion
        
        #region Parameter SubjectId_ImageDigest
        /// <summary>
        /// <para>
        /// <para>The digest of the image.</para>
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
        public System.String SubjectId_ImageDigest { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry that contains the
        /// repository in which to list image referrers. If you do not specify a registry, the
        /// default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository that contains the subject image.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of image referrer results returned by <c>ListImageReferrers</c>
        /// in paginated output. When this parameter is used, <c>ListImageReferrers</c> only returns
        /// <c>maxResults</c> results in a single page along with a <c>nextToken</c> response
        /// element. The remaining results of the initial request can be seen by sending another
        /// <c>ListImageReferrers</c> request with the returned <c>nextToken</c> value. This value
        /// can be between 1 and 50. If this parameter is not used, then <c>ListImageReferrers</c>
        /// returns up to 50 results and a <c>nextToken</c> value, if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a previous paginated <c>ListImageReferrers</c>
        /// request where <c>maxResults</c> was used and the results exceeded the value of that
        /// parameter. Pagination continues from the end of the previous results that returned
        /// the <c>nextToken</c> value. This value is <c>null</c> when there are no more results
        /// to return.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
        /// the next items in a list and not for other programmatic purposes.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Referrers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.ListImageReferrersResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.ListImageReferrersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Referrers";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RepositoryName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.ListImageReferrersResponse, GetECRImageReferrerListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RepositoryName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filter_ArtifactStatus = this.Filter_ArtifactStatus;
            if (this.Filter_ArtifactType != null)
            {
                context.Filter_ArtifactType = new List<System.String>(this.Filter_ArtifactType);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubjectId_ImageDigest = this.SubjectId_ImageDigest;
            #if MODULAR
            if (this.SubjectId_ImageDigest == null && ParameterWasBound(nameof(this.SubjectId_ImageDigest)))
            {
                WriteWarning("You are passing $null as a value for parameter SubjectId_ImageDigest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ECR.Model.ListImageReferrersRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.ECR.Model.ListImageReferrersFilter();
            Amazon.ECR.ArtifactStatusFilter requestFilter_filter_ArtifactStatus = null;
            if (cmdletContext.Filter_ArtifactStatus != null)
            {
                requestFilter_filter_ArtifactStatus = cmdletContext.Filter_ArtifactStatus;
            }
            if (requestFilter_filter_ArtifactStatus != null)
            {
                request.Filter.ArtifactStatus = requestFilter_filter_ArtifactStatus;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ArtifactType = null;
            if (cmdletContext.Filter_ArtifactType != null)
            {
                requestFilter_filter_ArtifactType = cmdletContext.Filter_ArtifactType;
            }
            if (requestFilter_filter_ArtifactType != null)
            {
                request.Filter.ArtifactTypes = requestFilter_filter_ArtifactType;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            
             // populate SubjectId
            var requestSubjectIdIsNull = true;
            request.SubjectId = new Amazon.ECR.Model.SubjectIdentifier();
            System.String requestSubjectId_subjectId_ImageDigest = null;
            if (cmdletContext.SubjectId_ImageDigest != null)
            {
                requestSubjectId_subjectId_ImageDigest = cmdletContext.SubjectId_ImageDigest;
            }
            if (requestSubjectId_subjectId_ImageDigest != null)
            {
                request.SubjectId.ImageDigest = requestSubjectId_subjectId_ImageDigest;
                requestSubjectIdIsNull = false;
            }
             // determine if request.SubjectId should be set to null
            if (requestSubjectIdIsNull)
            {
                request.SubjectId = null;
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
        
        private Amazon.ECR.Model.ListImageReferrersResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.ListImageReferrersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "ListImageReferrers");
            try
            {
                #if DESKTOP
                return client.ListImageReferrers(request);
                #elif CORECLR
                return client.ListImageReferrersAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ECR.ArtifactStatusFilter Filter_ArtifactStatus { get; set; }
            public List<System.String> Filter_ArtifactType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String SubjectId_ImageDigest { get; set; }
            public System.Func<Amazon.ECR.Model.ListImageReferrersResponse, GetECRImageReferrerListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Referrers;
        }
        
    }
}
