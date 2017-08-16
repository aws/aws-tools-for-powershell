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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Registers an on-premises instance.
    /// 
    ///  <note><para>
    /// Only one IAM ARN (an IAM session ARN or IAM user ARN) is supported in the request.
    /// You cannot use both.
    /// </para></note>
    /// </summary>
    [Cmdlet("Register", "CDOnPremiseInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Invokes the RegisterOnPremisesInstance operation against AWS CodeDeploy.", Operation = new[] {"RegisterOnPremisesInstance"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.CodeDeploy.Model.RegisterOnPremisesInstanceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterCDOnPremiseInstanceCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter IamSessionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM session to associate with the on-premises instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamSessionArn { get; set; }
        #endregion
        
        #region Parameter IamUserArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM user to associate with the on-premises instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamUserArn { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the on-premises instance to register.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CDOnPremiseInstance (RegisterOnPremisesInstance)"))
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
            
            context.IamSessionArn = this.IamSessionArn;
            context.IamUserArn = this.IamUserArn;
            context.InstanceName = this.InstanceName;
            
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
            var request = new Amazon.CodeDeploy.Model.RegisterOnPremisesInstanceRequest();
            
            if (cmdletContext.IamSessionArn != null)
            {
                request.IamSessionArn = cmdletContext.IamSessionArn;
            }
            if (cmdletContext.IamUserArn != null)
            {
                request.IamUserArn = cmdletContext.IamUserArn;
            }
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.CodeDeploy.Model.RegisterOnPremisesInstanceResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.RegisterOnPremisesInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "RegisterOnPremisesInstance");
            try
            {
                #if DESKTOP
                return client.RegisterOnPremisesInstance(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterOnPremisesInstanceAsync(request);
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
            public System.String IamSessionArn { get; set; }
            public System.String IamUserArn { get; set; }
            public System.String InstanceName { get; set; }
        }
        
    }
}
