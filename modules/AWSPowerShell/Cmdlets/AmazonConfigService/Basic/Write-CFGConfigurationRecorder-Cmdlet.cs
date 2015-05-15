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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates a new configuration recorder to record the resource configurations. 
    /// 
    ///  
    /// <para>
    /// You can use this action to change the role (<code>roleARN</code>) of an existing recorder.
    /// To change the role, call the action on the existing configuration recorder and specify
    /// a role.
    /// </para><note><para>
    /// Currently, you can specify only one configuration recorder per account. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConfigurationRecorder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutConfigurationRecorder operation against Amazon Config.", Operation = new[] {"PutConfigurationRecorder"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ConfigurationRecorderName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type PutConfigurationRecorderResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCFGConfigurationRecorderCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the recorder. By default, AWS Config automatically assigns the name "default"
        /// when creating the configuration recorder. You cannot change the assigned name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ConfigurationRecorder_Name")]
        public String ConfigurationRecorderName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the IAM role used to describe the AWS resources associated
        /// with the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ConfigurationRecorder_RoleARN { get; set; }
        
        /// <summary>
        /// Returns the value passed to the ConfigurationRecorderName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConfigurationRecorderName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConfigurationRecorder (PutConfigurationRecorder)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ConfigurationRecorderName = this.ConfigurationRecorderName;
            context.ConfigurationRecorder_RoleARN = this.ConfigurationRecorder_RoleARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PutConfigurationRecorderRequest();
            
            
             // populate ConfigurationRecorder
            bool requestConfigurationRecorderIsNull = true;
            request.ConfigurationRecorder = new ConfigurationRecorder();
            String requestConfigurationRecorder_configurationRecorderName = null;
            if (cmdletContext.ConfigurationRecorderName != null)
            {
                requestConfigurationRecorder_configurationRecorderName = cmdletContext.ConfigurationRecorderName;
            }
            if (requestConfigurationRecorder_configurationRecorderName != null)
            {
                request.ConfigurationRecorder.Name = requestConfigurationRecorder_configurationRecorderName;
                requestConfigurationRecorderIsNull = false;
            }
            String requestConfigurationRecorder_configurationRecorder_RoleARN = null;
            if (cmdletContext.ConfigurationRecorder_RoleARN != null)
            {
                requestConfigurationRecorder_configurationRecorder_RoleARN = cmdletContext.ConfigurationRecorder_RoleARN;
            }
            if (requestConfigurationRecorder_configurationRecorder_RoleARN != null)
            {
                request.ConfigurationRecorder.RoleARN = requestConfigurationRecorder_configurationRecorder_RoleARN;
                requestConfigurationRecorderIsNull = false;
            }
             // determine if request.ConfigurationRecorder should be set to null
            if (requestConfigurationRecorderIsNull)
            {
                request.ConfigurationRecorder = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutConfigurationRecorder(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ConfigurationRecorderName;
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
            public String ConfigurationRecorderName { get; set; }
            public String ConfigurationRecorder_RoleARN { get; set; }
        }
        
    }
}
