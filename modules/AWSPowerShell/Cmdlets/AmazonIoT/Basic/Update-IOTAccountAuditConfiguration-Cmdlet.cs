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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Configures or reconfigures the Device Defender audit settings for this account. Settings
    /// include how audit notifications are sent and which audit checks are enabled or disabled.
    /// </summary>
    [Cmdlet("Update", "IOTAccountAuditConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS IoT UpdateAccountAuditConfiguration API operation.", Operation = new[] {"UpdateAccountAuditConfiguration"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the RoleArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTAccountAuditConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AuditCheckConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies which audit checks are enabled and disabled for this account. Use <code>DescribeAccountAuditConfiguration</code>
        /// to see the list of all checks including those that are currently enabled.</para><para>Note that some data collection may begin immediately when certain checks are enabled.
        /// When a check is disabled, any data collected so far in relation to the check is deleted.</para><para>You cannot disable a check if it is used by any scheduled audit. You must first delete
        /// the check from the scheduled audit or delete the scheduled audit itself.</para><para>On the first call to <code>UpdateAccountAuditConfiguration</code> this parameter is
        /// required and must specify at least one enabled check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuditCheckConfigurations")]
        public System.Collections.Hashtable AuditCheckConfiguration { get; set; }
        #endregion
        
        #region Parameter AuditNotificationTargetConfiguration
        /// <summary>
        /// <para>
        /// <para>Information about the targets to which audit notifications are sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuditNotificationTargetConfigurations")]
        public System.Collections.Hashtable AuditNotificationTargetConfiguration { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that grants permission to AWS IoT to access information about
        /// your devices, policies, certificates and other items as necessary when performing
        /// an audit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the RoleArn parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTAccountAuditConfiguration (UpdateAccountAuditConfiguration)"))
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
            
            if (this.AuditCheckConfiguration != null)
            {
                context.AuditCheckConfigurations = new Dictionary<System.String, Amazon.IoT.Model.AuditCheckConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuditCheckConfiguration.Keys)
                {
                    context.AuditCheckConfigurations.Add((String)hashKey, (AuditCheckConfiguration)(this.AuditCheckConfiguration[hashKey]));
                }
            }
            if (this.AuditNotificationTargetConfiguration != null)
            {
                context.AuditNotificationTargetConfigurations = new Dictionary<System.String, Amazon.IoT.Model.AuditNotificationTarget>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuditNotificationTargetConfiguration.Keys)
                {
                    context.AuditNotificationTargetConfigurations.Add((String)hashKey, (AuditNotificationTarget)(this.AuditNotificationTargetConfiguration[hashKey]));
                }
            }
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.IoT.Model.UpdateAccountAuditConfigurationRequest();
            
            if (cmdletContext.AuditCheckConfigurations != null)
            {
                request.AuditCheckConfigurations = cmdletContext.AuditCheckConfigurations;
            }
            if (cmdletContext.AuditNotificationTargetConfigurations != null)
            {
                request.AuditNotificationTargetConfigurations = cmdletContext.AuditNotificationTargetConfigurations;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
                    pipelineOutput = this.RoleArn;
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
        
        private Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateAccountAuditConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateAccountAuditConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateAccountAuditConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateAccountAuditConfigurationAsync(request);
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
            public Dictionary<System.String, Amazon.IoT.Model.AuditCheckConfiguration> AuditCheckConfigurations { get; set; }
            public Dictionary<System.String, Amazon.IoT.Model.AuditNotificationTarget> AuditNotificationTargetConfigurations { get; set; }
            public System.String RoleArn { get; set; }
        }
        
    }
}
