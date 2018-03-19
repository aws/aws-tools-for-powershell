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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a lifecycle configuration that you can associate with a notebook instance.
    /// A <i>lifecycle configuration</i> is a collection of shell scripts that run when you
    /// create or start a notebook instance.
    /// 
    ///  
    /// <para>
    /// For information about notebook instance lifestyle configurations, see <a>notebook-lifecycle-config</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMNotebookInstanceLifecycleConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateNotebookInstanceLifecycleConfig API operation.", Operation = new[] {"CreateNotebookInstanceLifecycleConfig"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateNotebookInstanceLifecycleConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMNotebookInstanceLifecycleConfigCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter NotebookInstanceLifecycleConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the lifecycle configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String NotebookInstanceLifecycleConfigName { get; set; }
        #endregion
        
        #region Parameter OnCreate
        /// <summary>
        /// <para>
        /// <para>A shell script that runs only once, when you create a notebook instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.NotebookInstanceLifecycleHook[] OnCreate { get; set; }
        #endregion
        
        #region Parameter OnStart
        /// <summary>
        /// <para>
        /// <para>A shell script that runs every time you start a notebook instance, including when
        /// you create the notebook instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SageMaker.Model.NotebookInstanceLifecycleHook[] OnStart { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("NotebookInstanceLifecycleConfigName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMNotebookInstanceLifecycleConfig (CreateNotebookInstanceLifecycleConfig)"))
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
            
            context.NotebookInstanceLifecycleConfigName = this.NotebookInstanceLifecycleConfigName;
            if (this.OnCreate != null)
            {
                context.OnCreate = new List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook>(this.OnCreate);
            }
            if (this.OnStart != null)
            {
                context.OnStart = new List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook>(this.OnStart);
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
            var request = new Amazon.SageMaker.Model.CreateNotebookInstanceLifecycleConfigRequest();
            
            if (cmdletContext.NotebookInstanceLifecycleConfigName != null)
            {
                request.NotebookInstanceLifecycleConfigName = cmdletContext.NotebookInstanceLifecycleConfigName;
            }
            if (cmdletContext.OnCreate != null)
            {
                request.OnCreate = cmdletContext.OnCreate;
            }
            if (cmdletContext.OnStart != null)
            {
                request.OnStart = cmdletContext.OnStart;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NotebookInstanceLifecycleConfigArn;
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
        
        private Amazon.SageMaker.Model.CreateNotebookInstanceLifecycleConfigResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateNotebookInstanceLifecycleConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateNotebookInstanceLifecycleConfig");
            try
            {
                #if DESKTOP
                return client.CreateNotebookInstanceLifecycleConfig(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateNotebookInstanceLifecycleConfigAsync(request);
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
            public System.String NotebookInstanceLifecycleConfigName { get; set; }
            public List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook> OnCreate { get; set; }
            public List<Amazon.SageMaker.Model.NotebookInstanceLifecycleHook> OnStart { get; set; }
        }
        
    }
}
