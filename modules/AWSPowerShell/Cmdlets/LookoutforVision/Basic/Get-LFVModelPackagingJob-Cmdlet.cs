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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Describes an Amazon Lookout for Vision model packaging job. 
    /// 
    ///  
    /// <para>
    /// This operation requires permissions to perform the <c>lookoutvision:DescribeModelPackagingJob</c>
    /// operation.
    /// </para><para>
    /// For more information, see <i>Using your Amazon Lookout for Vision model on an edge
    /// device</i> in the Amazon Lookout for Vision Developer Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LFVModelPackagingJob")]
    [OutputType("Amazon.LookoutforVision.Model.ModelPackagingDescription")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision DescribeModelPackagingJob API operation.", Operation = new[] {"DescribeModelPackagingJob"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse))]
    [AWSCmdletOutput("Amazon.LookoutforVision.Model.ModelPackagingDescription or Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse",
        "This cmdlet returns an Amazon.LookoutforVision.Model.ModelPackagingDescription object.",
        "The service call response (type Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLFVModelPackagingJobCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The job name for the model packaging job. </para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project that contains the model packaging job that you want to describe.
        /// </para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelPackagingDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelPackagingDescription";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse, GetLFVModelPackagingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutforVision.Model.DescribeModelPackagingJobRequest();
            
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
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
        
        private Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.DescribeModelPackagingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "DescribeModelPackagingJob");
            try
            {
                return client.DescribeModelPackagingJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String JobName { get; set; }
            public System.String ProjectName { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.DescribeModelPackagingJobResponse, GetLFVModelPackagingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelPackagingDescription;
        }
        
    }
}
