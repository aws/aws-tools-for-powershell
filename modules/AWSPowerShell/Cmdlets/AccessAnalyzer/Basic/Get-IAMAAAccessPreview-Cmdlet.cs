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
using Amazon.AccessAnalyzer;
using Amazon.AccessAnalyzer.Model;

namespace Amazon.PowerShell.Cmdlets.IAMAA
{
    /// <summary>
    /// Retrieves information about an access preview for the specified analyzer.
    /// </summary>
    [Cmdlet("Get", "IAMAAAccessPreview")]
    [OutputType("Amazon.AccessAnalyzer.Model.AccessPreview")]
    [AWSCmdlet("Calls the AWS IAM Access Analyzer GetAccessPreview API operation.", Operation = new[] {"GetAccessPreview"}, SelectReturnType = typeof(Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse))]
    [AWSCmdletOutput("Amazon.AccessAnalyzer.Model.AccessPreview or Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse",
        "This cmdlet returns an Amazon.AccessAnalyzer.Model.AccessPreview object.",
        "The service call response (type Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIAMAAAccessPreviewCmdlet : AmazonAccessAnalyzerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessPreviewId
        /// <summary>
        /// <para>
        /// <para>The unique ID for the access preview.</para>
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
        public System.String AccessPreviewId { get; set; }
        #endregion
        
        #region Parameter AnalyzerArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access-analyzer-getting-started.html#permission-resources">ARN
        /// of the analyzer</a> used to generate the access preview.</para>
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
        public System.String AnalyzerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccessPreview'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse).
        /// Specifying the name of a property of type Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccessPreview";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse, GetIAMAAAccessPreviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessPreviewId = this.AccessPreviewId;
            #if MODULAR
            if (this.AccessPreviewId == null && ParameterWasBound(nameof(this.AccessPreviewId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessPreviewId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnalyzerArn = this.AnalyzerArn;
            #if MODULAR
            if (this.AnalyzerArn == null && ParameterWasBound(nameof(this.AnalyzerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnalyzerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AccessAnalyzer.Model.GetAccessPreviewRequest();
            
            if (cmdletContext.AccessPreviewId != null)
            {
                request.AccessPreviewId = cmdletContext.AccessPreviewId;
            }
            if (cmdletContext.AnalyzerArn != null)
            {
                request.AnalyzerArn = cmdletContext.AnalyzerArn;
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
        
        private Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse CallAWSServiceOperation(IAmazonAccessAnalyzer client, Amazon.AccessAnalyzer.Model.GetAccessPreviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IAM Access Analyzer", "GetAccessPreview");
            try
            {
                #if DESKTOP
                return client.GetAccessPreview(request);
                #elif CORECLR
                return client.GetAccessPreviewAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessPreviewId { get; set; }
            public System.String AnalyzerArn { get; set; }
            public System.Func<Amazon.AccessAnalyzer.Model.GetAccessPreviewResponse, GetIAMAAAccessPreviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccessPreview;
        }
        
    }
}
