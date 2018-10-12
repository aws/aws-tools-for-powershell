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
    /// Sets a limit on the number of concurrent executions available to this function. It
    /// is a subset of your account's total concurrent execution limit per region. Note that
    /// Lambda automatically reserves a buffer of 100 concurrent executions for functions
    /// without any reserved concurrency limit. This means if your account limit is 1000,
    /// you have a total of 900 available to allocate to individual functions. For more information,
    /// see <a href="http://docs.aws.amazon.com/lambda/latest/dg/concurrent-executions.html">Managing
    /// Concurrency</a>.
    /// </summary>
    [Cmdlet("Write", "LMFunctionConcurrency", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int32")]
    [AWSCmdlet("Calls the AWS Lambda PutFunctionConcurrency API operation.", Operation = new[] {"PutFunctionConcurrency"})]
    [AWSCmdletOutput("System.Int32",
        "This cmdlet returns a Int32 object.",
        "The service call response (type Amazon.Lambda.Model.PutFunctionConcurrencyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLMFunctionConcurrencyCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// Amazon.Lambda.Model.PutFunctionConcurrencyRequest.FunctionName
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter ReservedConcurrentExecution
        /// <summary>
        /// <para>
        /// <para>The concurrent execution limit reserved for this function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReservedConcurrentExecutions")]
        public System.Int32 ReservedConcurrentExecution { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMFunctionConcurrency (PutFunctionConcurrency)"))
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
            
            context.FunctionName = this.FunctionName;
            if (ParameterWasBound("ReservedConcurrentExecution"))
                context.ReservedConcurrentExecutions = this.ReservedConcurrentExecution;
            
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
            var request = new Amazon.Lambda.Model.PutFunctionConcurrencyRequest();
            
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.ReservedConcurrentExecutions != null)
            {
                request.ReservedConcurrentExecutions = cmdletContext.ReservedConcurrentExecutions.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedConcurrentExecutions;
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
        
        private Amazon.Lambda.Model.PutFunctionConcurrencyResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.PutFunctionConcurrencyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "PutFunctionConcurrency");
            try
            {
                #if DESKTOP
                return client.PutFunctionConcurrency(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutFunctionConcurrencyAsync(request);
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
            public System.String FunctionName { get; set; }
            public System.Int32? ReservedConcurrentExecutions { get; set; }
        }
        
    }
}
