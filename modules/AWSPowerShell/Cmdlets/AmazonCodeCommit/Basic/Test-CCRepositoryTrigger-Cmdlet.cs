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
    /// Tests the functionality of repository triggers by sending information to the trigger
    /// target. If real data is available in the repository, the test will send data from
    /// the last commit. If no data is available, sample data will be generated.
    /// </summary>
    [Cmdlet("Test", "CCRepositoryTrigger")]
    [OutputType("Amazon.CodeCommit.Model.TestRepositoryTriggersResponse")]
    [AWSCmdlet("Invokes the TestRepositoryTriggers operation against AWS CodeCommit.", Operation = new[] {"TestRepositoryTriggers"})]
    [AWSCmdletOutput("Amazon.CodeCommit.Model.TestRepositoryTriggersResponse",
        "This cmdlet returns a Amazon.CodeCommit.Model.TestRepositoryTriggersResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestCCRepositoryTriggerCmdlet : AmazonCodeCommitClientCmdlet, IExecutor
    {
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository in which to test the triggers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter Trigger
        /// <summary>
        /// <para>
        /// <para>The list of triggers to test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Triggers")]
        public Amazon.CodeCommit.Model.RepositoryTrigger[] Trigger { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
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
            var request = new Amazon.CodeCommit.Model.TestRepositoryTriggersRequest();
            
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
        
        private Amazon.CodeCommit.Model.TestRepositoryTriggersResponse CallAWSServiceOperation(IAmazonCodeCommit client, Amazon.CodeCommit.Model.TestRepositoryTriggersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCommit", "TestRepositoryTriggers");
            #if DESKTOP
            return client.TestRepositoryTriggers(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.TestRepositoryTriggersAsync(request);
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
