/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CodeGuruSecurity;
using Amazon.CodeGuruSecurity.Model;

namespace Amazon.PowerShell.Cmdlets.CGS
{
    /// <summary>
    /// Use to create a scan using code uploaded to an S3 bucket.
    /// </summary>
    [Cmdlet("New", "CGSScan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeGuruSecurity.Model.CreateScanResponse")]
    [AWSCmdlet("Calls the Amazon CodeGuru Security CreateScan API operation.", Operation = new[] {"CreateScan"}, SelectReturnType = typeof(Amazon.CodeGuruSecurity.Model.CreateScanResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruSecurity.Model.CreateScanResponse",
        "This cmdlet returns an Amazon.CodeGuruSecurity.Model.CreateScanResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGSScanCmdlet : AmazonCodeGuruSecurityClientCmdlet, IExecutor
    {
        
        #region Parameter AnalysisType
        /// <summary>
        /// <para>
        /// <para>The type of analysis you want CodeGuru Security to perform in the scan, either <code>Security</code>
        /// or <code>All</code>. The <code>Security</code> type only generates findings related
        /// to security. The <code>All</code> type generates both security findings and quality
        /// findings. Defaults to <code>Security</code> type if missing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeGuruSecurity.AnalysisType")]
        public Amazon.CodeGuruSecurity.AnalysisType AnalysisType { get; set; }
        #endregion
        
        #region Parameter ResourceId_CodeArtifactId
        /// <summary>
        /// <para>
        /// <para>The identifier for the code file uploaded to the resource where a finding was detected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId_CodeArtifactId { get; set; }
        #endregion
        
        #region Parameter ScanName
        /// <summary>
        /// <para>
        /// <para>The unique name that CodeGuru Security uses to track revisions across multiple scans
        /// of the same resource. Only allowed for a <code>STANDARD</code> scan type. If not specified,
        /// it will be auto generated. </para>
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
        public System.String ScanName { get; set; }
        #endregion
        
        #region Parameter ScanType
        /// <summary>
        /// <para>
        /// <para>The type of scan, either <code>Standard</code> or <code>Express</code>. Defaults to
        /// <code>Standard</code> type if missing.</para><para><code>Express</code> scans run on limited resources and use a limited set of detectors
        /// to analyze your code in near-real time. <code>Standard</code> scans have standard
        /// resource limits and use the full set of detectors to analyze your code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeGuruSecurity.ScanType")]
        public Amazon.CodeGuruSecurity.ScanType ScanType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs used to tag a scan. A tag is a custom attribute label
        /// with two parts:</para><ul><li><para>A tag key. For example, <code>CostCenter</code>, <code>Environment</code>, or <code>Secret</code>.
        /// Tag keys are case sensitive.</para></li><li><para>An optional tag value field. For example, <code>111122223333</code>, <code>Production</code>,
        /// or a team name. Omitting the tag value is the same as using an empty string. Tag values
        /// are case sensitive.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token for the request. Amazon CodeGuru Security uses this value to
        /// prevent the accidental creation of duplicate scans if there are failures and retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruSecurity.Model.CreateScanResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruSecurity.Model.CreateScanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScanName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScanName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScanName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGSScan (CreateScan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruSecurity.Model.CreateScanResponse, NewCGSScanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScanName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnalysisType = this.AnalysisType;
            context.ClientToken = this.ClientToken;
            context.ResourceId_CodeArtifactId = this.ResourceId_CodeArtifactId;
            context.ScanName = this.ScanName;
            #if MODULAR
            if (this.ScanName == null && ParameterWasBound(nameof(this.ScanName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanType = this.ScanType;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.CodeGuruSecurity.Model.CreateScanRequest();
            
            if (cmdletContext.AnalysisType != null)
            {
                request.AnalysisType = cmdletContext.AnalysisType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ResourceId
            var requestResourceIdIsNull = true;
            request.ResourceId = new Amazon.CodeGuruSecurity.Model.ResourceId();
            System.String requestResourceId_resourceId_CodeArtifactId = null;
            if (cmdletContext.ResourceId_CodeArtifactId != null)
            {
                requestResourceId_resourceId_CodeArtifactId = cmdletContext.ResourceId_CodeArtifactId;
            }
            if (requestResourceId_resourceId_CodeArtifactId != null)
            {
                request.ResourceId.CodeArtifactId = requestResourceId_resourceId_CodeArtifactId;
                requestResourceIdIsNull = false;
            }
             // determine if request.ResourceId should be set to null
            if (requestResourceIdIsNull)
            {
                request.ResourceId = null;
            }
            if (cmdletContext.ScanName != null)
            {
                request.ScanName = cmdletContext.ScanName;
            }
            if (cmdletContext.ScanType != null)
            {
                request.ScanType = cmdletContext.ScanType;
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
        
        private Amazon.CodeGuruSecurity.Model.CreateScanResponse CallAWSServiceOperation(IAmazonCodeGuruSecurity client, Amazon.CodeGuruSecurity.Model.CreateScanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Security", "CreateScan");
            try
            {
                #if DESKTOP
                return client.CreateScan(request);
                #elif CORECLR
                return client.CreateScanAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CodeGuruSecurity.AnalysisType AnalysisType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ResourceId_CodeArtifactId { get; set; }
            public System.String ScanName { get; set; }
            public Amazon.CodeGuruSecurity.ScanType ScanType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CodeGuruSecurity.Model.CreateScanResponse, NewCGSScanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
