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
using Amazon.ResourceGroupsTaggingAPI;
using Amazon.ResourceGroupsTaggingAPI.Model;

namespace Amazon.PowerShell.Cmdlets.RGT
{
    /// <summary>
    /// Generates a report that lists all tagged resources in the accounts across your organization
    /// and tells whether each resource is compliant with the effective tag policy. Compliance
    /// data is refreshed daily. The report is generated asynchronously.
    /// 
    ///  
    /// <para>
    /// The generated report is saved to the following location:
    /// </para><para><c>s3://example-bucket/AwsTagPolicies/o-exampleorgid/YYYY-MM-ddTHH:mm:ssZ/report.csv</c></para><para>
    /// You can call this operation only from the organization's management account and from
    /// the us-east-1 Region.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "RGTReportCreation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Resource Groups Tagging API StartReportCreation API operation.", Operation = new[] {"StartReportCreation"}, SelectReturnType = typeof(Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationResponse))]
    [AWSCmdletOutput("None or Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartRGTReportCreationCmdlet : AmazonResourceGroupsTaggingAPIClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where the report will be stored; for example:</para><para><c>awsexamplebucket</c></para><para>For more information on S3 bucket requirements, including an example bucket policy,
        /// see the example S3 bucket policy on this page.</para>
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
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the S3Bucket parameter.
        /// The -PassThru parameter is deprecated, use -Select '^S3Bucket' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^S3Bucket' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.S3Bucket), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RGTReportCreation (StartReportCreation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationResponse, StartRGTReportCreationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.S3Bucket;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3Bucket = this.S3Bucket;
            #if MODULAR
            if (this.S3Bucket == null && ParameterWasBound(nameof(this.S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationRequest();
            
            if (cmdletContext.S3Bucket != null)
            {
                request.S3Bucket = cmdletContext.S3Bucket;
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
        
        private Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationResponse CallAWSServiceOperation(IAmazonResourceGroupsTaggingAPI client, Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups Tagging API", "StartReportCreation");
            try
            {
                #if DESKTOP
                return client.StartReportCreation(request);
                #elif CORECLR
                return client.StartReportCreationAsync(request).GetAwaiter().GetResult();
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
            public System.String S3Bucket { get; set; }
            public System.Func<Amazon.ResourceGroupsTaggingAPI.Model.StartReportCreationResponse, StartRGTReportCreationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
