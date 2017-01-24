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
using Amazon.CodeCommit;
using Amazon.CodeCommit.Model;

namespace Amazon.PowerShell.Cmdlets.CC
{
    /// <summary>
    /// Replaces all triggers for a repository. This can be used to create or delete triggers.
    /// </summary>
    [Cmdlet("Set", "CCRepositoryTrigger", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the PutRepositoryTriggers operation against AWS CodeCommit.", Operation = new[] {"PutRepositoryTriggers"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CodeCommit.Model.PutRepositoryTriggersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCCRepositoryTriggerCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository where you want to create or update the trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter Trigger
        /// <summary>
        /// <para>
        /// <para>The JSON block of configuration information for each trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Triggers")]
        public Amazon.CodeCommit.Model.RepositoryTrigger[] Trigger { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RepositoryName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CCRepositoryTrigger (PutRepositoryTriggers)"))
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
            
            context.RepositoryName = this.RepositoryName;
            if (this.Trigger != null)
            {
                context.Triggers = new List<Amazon.CodeCommit.Model.RepositoryTrigger>(this.Trigger);
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
            var request = new Amazon.CodeCommit.Model.PutRepositoryTriggersRequest();
            
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
            }
            if (cmdletContext.Triggers != null)
            {
                request.Triggers = cmdletContext.Triggers;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ConfigurationId;
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
        
        private static Amazon.CodeCommit.Model.PutRepositoryTriggersResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.PutRepositoryTriggersRequest request)
        {
            #if DESKTOP
            return client.PutRepositoryTriggers(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutRepositoryTriggersAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String RepositoryName { get; set; }
            public List<Amazon.CodeCommit.Model.RepositoryTrigger> Triggers { get; set; }
        }
        
    }
}
