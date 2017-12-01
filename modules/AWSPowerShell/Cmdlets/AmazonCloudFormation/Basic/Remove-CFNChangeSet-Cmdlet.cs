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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Deletes the specified change set. Deleting change sets ensures that no one executes
    /// the wrong change set.
    /// 
    ///  
    /// <para>
    /// If the call successfully completes, AWS CloudFormation successfully deleted the change
    /// set.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CFNChangeSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation DeleteChangeSet API operation.", Operation = new[] {"DeleteChangeSet"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ChangeSetName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudFormation.Model.DeleteChangeSetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCFNChangeSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeSetName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the change set that you want to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ChangeSetName { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>If you specified the name of a change set to delete, specify the stack name or ID
        /// (ARN) that is associated with it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ChangeSetName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ChangeSetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFNChangeSet (DeleteChangeSet)"))
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
            
            context.ChangeSetName = this.ChangeSetName;
            context.StackName = this.StackName;
            
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
            var request = new Amazon.CloudFormation.Model.DeleteChangeSetRequest();
            
            if (cmdletContext.ChangeSetName != null)
            {
                request.ChangeSetName = cmdletContext.ChangeSetName;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ChangeSetName;
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
        
        private Amazon.CloudFormation.Model.DeleteChangeSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DeleteChangeSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DeleteChangeSet");
            try
            {
                #if DESKTOP
                return client.DeleteChangeSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteChangeSetAsync(request);
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
            public System.String ChangeSetName { get; set; }
            public System.String StackName { get; set; }
        }
        
    }
}
