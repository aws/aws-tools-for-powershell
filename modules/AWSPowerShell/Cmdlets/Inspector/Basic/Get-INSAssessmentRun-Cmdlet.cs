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
using Amazon.Inspector;
using Amazon.Inspector.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Describes the assessment runs that are specified by the ARNs of the assessment runs.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentRun")]
    [OutputType("Amazon.Inspector.Model.DescribeAssessmentRunsResponse")]
    [AWSCmdlet("Calls the Amazon Inspector DescribeAssessmentRuns API operation.", Operation = new[] {"DescribeAssessmentRuns"}, SelectReturnType = typeof(Amazon.Inspector.Model.DescribeAssessmentRunsResponse))]
    [AWSCmdletOutput("Amazon.Inspector.Model.DescribeAssessmentRunsResponse",
        "This cmdlet returns an Amazon.Inspector.Model.DescribeAssessmentRunsResponse object containing multiple properties."
    )]
    public partial class GetINSAssessmentRunCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentRunArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the assessment run that you want to describe.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AssessmentRunArns")]
        public System.String[] AssessmentRunArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.DescribeAssessmentRunsResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.DescribeAssessmentRunsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.DescribeAssessmentRunsResponse, GetINSAssessmentRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssessmentRunArn != null)
            {
                context.AssessmentRunArn = new List<System.String>(this.AssessmentRunArn);
            }
            #if MODULAR
            if (this.AssessmentRunArn == null && ParameterWasBound(nameof(this.AssessmentRunArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentRunArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector.Model.DescribeAssessmentRunsRequest();
            
            if (cmdletContext.AssessmentRunArn != null)
            {
                request.AssessmentRunArns = cmdletContext.AssessmentRunArn;
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
        
        private Amazon.Inspector.Model.DescribeAssessmentRunsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.DescribeAssessmentRunsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "DescribeAssessmentRuns");
            try
            {
                return client.DescribeAssessmentRunsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AssessmentRunArn { get; set; }
            public System.Func<Amazon.Inspector.Model.DescribeAssessmentRunsResponse, GetINSAssessmentRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
