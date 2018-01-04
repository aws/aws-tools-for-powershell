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
using Amazon.ServerlessApplicationRepository;
using Amazon.ServerlessApplicationRepository.Model;

namespace Amazon.PowerShell.Cmdlets.SAR
{
    /// <summary>
    /// Creates an AWS CloudFormation ChangeSet for the given application.
    /// </summary>
    [Cmdlet("New", "SARCloudFormationChangeSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServerlessApplicationRepository.Model.CreateCloudFormationChangeSetResponse")]
    [AWSCmdlet("Calls the AWS Serverless Application Repository CreateCloudFormationChangeSet API operation.", Operation = new[] {"CreateCloudFormationChangeSet"})]
    [AWSCmdletOutput("Amazon.ServerlessApplicationRepository.Model.CreateCloudFormationChangeSetResponse",
        "This cmdlet returns a Amazon.ServerlessApplicationRepository.Model.CreateCloudFormationChangeSetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSARCloudFormationChangeSetCmdlet : AmazonServerlessApplicationRepositoryClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// The id of the application to create the
        /// ChangeSet for
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ParameterOverride
        /// <summary>
        /// <para>
        /// A list of parameter values for the
        /// parameters of the application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterOverrides")]
        public Amazon.ServerlessApplicationRepository.Model.ParameterValue[] ParameterOverride { get; set; }
        #endregion
        
        #region Parameter SemanticVersion
        /// <summary>
        /// <para>
        /// The semantic version of the application:\n\n
        /// https://semver.org/
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SemanticVersion { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// The name or the unique ID of the stack for which
        /// you are creating a change set. AWS CloudFormation generates\n the change set by comparing
        /// this stack's information with the information that you submit, such as a modified\n
        /// template or different parameter input values. \nConstraints: Minimum length of 1.\nPattern:
        /// ([a-zA-Z][-a-zA-Z0-9]*)|(arn:\b(aws|aws-us-gov|aws-cn)\b:[-a-zA-Z0-9:/._+]*)
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StackName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SARCloudFormationChangeSet (CreateCloudFormationChangeSet)"))
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
            
            context.ApplicationId = this.ApplicationId;
            if (this.ParameterOverride != null)
            {
                context.ParameterOverrides = new List<Amazon.ServerlessApplicationRepository.Model.ParameterValue>(this.ParameterOverride);
            }
            context.SemanticVersion = this.SemanticVersion;
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
            var request = new Amazon.ServerlessApplicationRepository.Model.CreateCloudFormationChangeSetRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ParameterOverrides != null)
            {
                request.ParameterOverrides = cmdletContext.ParameterOverrides;
            }
            if (cmdletContext.SemanticVersion != null)
            {
                request.SemanticVersion = cmdletContext.SemanticVersion;
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
        
        private Amazon.ServerlessApplicationRepository.Model.CreateCloudFormationChangeSetResponse CallAWSServiceOperation(IAmazonServerlessApplicationRepository client, Amazon.ServerlessApplicationRepository.Model.CreateCloudFormationChangeSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Serverless Application Repository", "CreateCloudFormationChangeSet");
            try
            {
                #if DESKTOP
                return client.CreateCloudFormationChangeSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCloudFormationChangeSetAsync(request);
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
            public System.String ApplicationId { get; set; }
            public List<Amazon.ServerlessApplicationRepository.Model.ParameterValue> ParameterOverrides { get; set; }
            public System.String SemanticVersion { get; set; }
            public System.String StackName { get; set; }
        }
        
    }
}
