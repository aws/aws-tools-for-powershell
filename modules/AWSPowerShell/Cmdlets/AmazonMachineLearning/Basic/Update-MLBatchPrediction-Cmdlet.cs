/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MachineLearning;
using Amazon.MachineLearning.Model;

namespace Amazon.PowerShell.Cmdlets.ML
{
    /// <summary>
    /// Updates the <code>BatchPredictionName</code> of a <code>BatchPrediction</code>.
    /// 
    ///  
    /// <para>
    /// You can use the <code>GetBatchPrediction</code> operation to view the contents of
    /// the updated data element.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MLBatchPrediction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateBatchPrediction operation against Amazon Machine Learning.", Operation = new[] {"UpdateBatchPrediction"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.MachineLearning.Model.UpdateBatchPredictionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMLBatchPredictionCmdlet : AmazonMachineLearningClientCmdlet, IExecutor
    {
        
        #region Parameter BatchPredictionId
        /// <summary>
        /// <para>
        /// <para>The ID assigned to the <code>BatchPrediction</code> during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BatchPredictionId { get; set; }
        #endregion
        
        #region Parameter BatchPredictionName
        /// <summary>
        /// <para>
        /// <para>A new user-supplied name or description of the <code>BatchPrediction</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Name")]
        public System.String BatchPredictionName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BatchPredictionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MLBatchPrediction (UpdateBatchPrediction)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.BatchPredictionId = this.BatchPredictionId;
            context.BatchPredictionName = this.BatchPredictionName;
            
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
            var request = new Amazon.MachineLearning.Model.UpdateBatchPredictionRequest();
            
            if (cmdletContext.BatchPredictionId != null)
            {
                request.BatchPredictionId = cmdletContext.BatchPredictionId;
            }
            if (cmdletContext.BatchPredictionName != null)
            {
                request.BatchPredictionName = cmdletContext.BatchPredictionName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BatchPredictionId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.MachineLearning.Model.UpdateBatchPredictionResponse CallAWSServiceOperation(IAmazonMachineLearning client, Amazon.MachineLearning.Model.UpdateBatchPredictionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Machine Learning", "UpdateBatchPrediction");
            #if DESKTOP
            return client.UpdateBatchPrediction(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateBatchPredictionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String BatchPredictionId { get; set; }
            public System.String BatchPredictionName { get; set; }
        }
        
    }
}
