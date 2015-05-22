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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Disables single-sign on for a directory.
    /// </summary>
    [Cmdlet("Disable", "DSSso", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the DisableSso operation against AWS Directory Service.", Operation = new[] {"DisableSso"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DirectoryId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type DisableSsoResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class DisableDSSsoCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory to disable single-sign on for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String DirectoryId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The password of an alternate account to use to disable single-sign on. This is only
        /// used for AD Connector directories. See the <i>UserName</i> parameter for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Password { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The username of an alternate account to use to disable single-sign on. This is only
        /// used for AD Connector directories. This account must have privileges to remove a service
        /// principle name. </para><para>If the AD Connector service account does not have privileges to remove a service principle
        /// name, you can specify an alternate account with the <i>UserName</i> and <i>Password</i>
        /// parameters. These credentials are only used to disable single sign-on and are not
        /// stored by the service. The AD Connector service account is not changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String UserName { get; set; }
        
        /// <summary>
        /// Returns the value passed to the DirectoryId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-DSSso (DisableSso)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DirectoryId = this.DirectoryId;
            context.Password = this.Password;
            context.UserName = this.UserName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DisableSsoRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DisableSso(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.DirectoryId;
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
            public String DirectoryId { get; set; }
            public String Password { get; set; }
            public String UserName { get; set; }
        }
        
    }
}
