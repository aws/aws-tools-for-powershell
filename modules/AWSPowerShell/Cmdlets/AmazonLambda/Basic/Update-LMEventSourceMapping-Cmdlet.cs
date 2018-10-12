/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// You can update an event source mapping. This is useful if you want to change the parameters
    /// of the existing mapping without losing your position in the stream. You can change
    /// which function will receive the stream records, but to change the stream itself, you
    /// must create a new mapping.
    /// 
    ///  
    /// <para>
    /// If you disable the event source mapping, AWS Lambda stops polling. If you enable again,
    /// it will resume polling from the time it had stopped polling, so you don't lose processing
    /// of any records. However, if you delete event source mapping and create it again, it
    /// will reset.
    /// </para><para>
    /// This operation requires permission for the <code>lambda:UpdateEventSourceMapping</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMEventSourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateEventSourceMappingResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateEventSourceMapping API operation.", Operation = new[] {"UpdateEventSourceMapping"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateEventSourceMappingResponse",
        "This cmdlet returns a Amazon.Lambda.Model.UpdateEventSourceMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMEventSourceMappingCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter BatchSize
        /// <summary>
        /// <para>
        /// <para>The largest number of records that AWS Lambda will retrieve from your event source
        /// at the time of invoking your function. Your function receives an event with all the
        /// retrieved records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BatchSize { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether AWS Lambda should actively poll the stream or not. If disabled,
        /// AWS Lambda will not poll the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enabled { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.UpdateEventSourceMappingRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter UUID
        /// <summary>
        /// <para>
        /// <para>The event source mapping identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UUID { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMEventSourceMapping (UpdateEventSourceMapping)"))
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
            
            if (ParameterWasBound("BatchSize"))
                context.BatchSize = this.BatchSize;
            if (ParameterWasBound("Enabled"))
                context.Enabled = this.Enabled;
            context.FunctionName = this.FunctionName;
            context.UUID = this.UUID;
            
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
            var request = new Amazon.Lambda.Model.UpdateEventSourceMappingRequest();
            
            if (cmdletContext.BatchSize != null)
            {
                request.BatchSize = cmdletContext.BatchSize.Value;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.UUID != null)
            {
                request.UUID = cmdletContext.UUID;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Lambda.Model.UpdateEventSourceMappingResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateEventSourceMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateEventSourceMapping");
            try
            {
                #if DESKTOP
                return client.UpdateEventSourceMapping(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateEventSourceMappingAsync(request);
                return task.Result;
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
            public System.Int32? BatchSize { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String FunctionName { get; set; }
            public System.String UUID { get; set; }
        }
        
    }
}
