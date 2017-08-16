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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Registers your on-premises server or virtual machine with Amazon EC2 so that you can
    /// manage these resources using Run Command. An on-premises server or virtual machine
    /// that has been registered with EC2 is called a managed instance. For more information
    /// about activations, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/systems-manager-managedinstances.html">Setting
    /// Up Systems Manager in Hybrid Environments</a>.
    /// </summary>
    [Cmdlet("New", "SSMActivation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.CreateActivationResponse")]
    [AWSCmdlet("Invokes the CreateActivation operation against Amazon Simple Systems Management.", Operation = new[] {"CreateActivation"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.CreateActivationResponse",
        "This cmdlet returns a Amazon.SimpleSystemsManagement.Model.CreateActivationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMActivationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter DefaultInstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the registered, managed instance as it will appear in the Amazon EC2 console
        /// or when you use the AWS command line tools to list EC2 resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultInstanceName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A userdefined description of the resource that you want to register with Amazon EC2.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExpirationDate
        /// <summary>
        /// <para>
        /// <para>The date by which this activation request should expire. The default value is 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ExpirationDate { get; set; }
        #endregion
        
        #region Parameter IamRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Identity and Access Management (IAM) role that you want to assign to the
        /// managed instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamRole { get; set; }
        #endregion
        
        #region Parameter RegistrationLimit
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of managed instances you want to register. The default
        /// value is 1 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 RegistrationLimit { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DefaultInstanceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMActivation (CreateActivation)"))
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
            
            context.DefaultInstanceName = this.DefaultInstanceName;
            context.Description = this.Description;
            if (ParameterWasBound("ExpirationDate"))
                context.ExpirationDate = this.ExpirationDate;
            context.IamRole = this.IamRole;
            if (ParameterWasBound("RegistrationLimit"))
                context.RegistrationLimit = this.RegistrationLimit;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateActivationRequest();
            
            if (cmdletContext.DefaultInstanceName != null)
            {
                request.DefaultInstanceName = cmdletContext.DefaultInstanceName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExpirationDate != null)
            {
                request.ExpirationDate = cmdletContext.ExpirationDate.Value;
            }
            if (cmdletContext.IamRole != null)
            {
                request.IamRole = cmdletContext.IamRole;
            }
            if (cmdletContext.RegistrationLimit != null)
            {
                request.RegistrationLimit = cmdletContext.RegistrationLimit.Value;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateActivationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateActivationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "CreateActivation");
            try
            {
                #if DESKTOP
                return client.CreateActivation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateActivationAsync(request);
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
            public System.String DefaultInstanceName { get; set; }
            public System.String Description { get; set; }
            public System.DateTime? ExpirationDate { get; set; }
            public System.String IamRole { get; set; }
            public System.Int32? RegistrationLimit { get; set; }
        }
        
    }
}
