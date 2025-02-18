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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Returns information about a trained model inference job.
    /// </summary>
    [Cmdlet("Get", "CRMLTrainedModelInferenceJob")]
    [OutputType("Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse")]
    [AWSCmdlet("Calls the CleanRoomsML GetTrainedModelInferenceJob API operation.", Operation = new[] {"GetTrainedModelInferenceJob"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse))]
    [AWSCmdletOutput("Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse",
        "This cmdlet returns an Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse object containing multiple properties."
    )]
    public partial class GetCRMLTrainedModelInferenceJobCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>Provides the membership ID of the membership that contains the trained model inference
        /// job that you are interested in.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter TrainedModelInferenceJobArn
        /// <summary>
        /// <para>
        /// <para>Provides the Amazon Resource Name (ARN) of the trained model inference job that you
        /// are interested in.</para>
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
        public System.String TrainedModelInferenceJobArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse, GetCRMLTrainedModelInferenceJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainedModelInferenceJobArn = this.TrainedModelInferenceJobArn;
            #if MODULAR
            if (this.TrainedModelInferenceJobArn == null && ParameterWasBound(nameof(this.TrainedModelInferenceJobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainedModelInferenceJobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobRequest();
            
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.TrainedModelInferenceJobArn != null)
            {
                request.TrainedModelInferenceJobArn = cmdletContext.TrainedModelInferenceJobArn;
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
        
        private Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "GetTrainedModelInferenceJob");
            try
            {
                return client.GetTrainedModelInferenceJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MembershipIdentifier { get; set; }
            public System.String TrainedModelInferenceJobArn { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.GetTrainedModelInferenceJobResponse, GetCRMLTrainedModelInferenceJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
