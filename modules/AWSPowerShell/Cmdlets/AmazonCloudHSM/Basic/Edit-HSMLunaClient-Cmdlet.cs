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
using Amazon.CloudHSM;
using Amazon.CloudHSM.Model;

namespace Amazon.PowerShell.Cmdlets.HSM
{
    /// <summary>
    /// Modifies the certificate used by the client.
    /// 
    ///  
    /// <para>
    /// This action can potentially start a workflow to install the new certificate on the
    /// client's HSMs.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "HSMLunaClient", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ModifyLunaClient operation against AWS Cloud HSM.", Operation = new[] {"ModifyLunaClient"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudHSM.Model.ModifyLunaClientResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditHSMLunaClientCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The new certificate for the client. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Certificate { get; set; }
        #endregion
        
        #region Parameter ClientArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClientArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClientArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-HSMLunaClient (ModifyLunaClient)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Certificate = this.Certificate;
            context.ClientArn = this.ClientArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudHSM.Model.ModifyLunaClientRequest();
            
            if (cmdletContext.Certificate != null)
            {
                request.Certificate = cmdletContext.Certificate;
            }
            if (cmdletContext.ClientArn != null)
            {
                request.ClientArn = cmdletContext.ClientArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifyLunaClient(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ClientArn;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Certificate { get; set; }
            public System.String ClientArn { get; set; }
        }
        
    }
}
