/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateAccountAuditConfiguration</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTAccountAuditConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateAccountAuditConfiguration API operation.", Operation = new[] {"UpdateAccountAuditConfiguration"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTAccountAuditConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuditCheckConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies which audit checks are enabled and disabled for this account. Use <c>DescribeAccountAuditConfiguration</c>
        /// to see the list of all checks, including those that are currently enabled.</para><para>Some data collection might start immediately when certain checks are enabled. When
        /// a check is disabled, any data collected so far in relation to the check is deleted.</para><para>You cannot disable a check if it's used by any scheduled audit. You must first delete
        /// the check from the scheduled audit or delete the scheduled audit itself.</para><para>On the first call to <c>UpdateAccountAuditConfiguration</c>, this parameter is required
        /// and must specify at least one enabled check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuditCheckConfigurations")]
        public System.Collections.Hashtable AuditCheckConfiguration { get; set; }
        #endregion
        
        #region Parameter AuditNotificationTargetConfiguration
        /// <summary>
        /// <para>
        /// <para>Information about the targets to which audit notifications are sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuditNotificationTargetConfigurations")]
        public System.Collections.Hashtable AuditNotificationTargetConfiguration { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role that grants permission to IoT to access
        /// information about your devices, policies, certificates, and other items as required
        /// when performing an audit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RoleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RoleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RoleArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTAccountAuditConfiguration (UpdateAccountAuditConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse, UpdateIOTAccountAuditConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RoleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AuditCheckConfiguration != null)
            {
                context.AuditCheckConfiguration = new Dictionary<System.String, Amazon.IoT.Model.AuditCheckConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuditCheckConfiguration.Keys)
                {
                    context.AuditCheckConfiguration.Add((String)hashKey, (Amazon.IoT.Model.AuditCheckConfiguration)(this.AuditCheckConfiguration[hashKey]));
                }
            }
            if (this.AuditNotificationTargetConfiguration != null)
            {
                context.AuditNotificationTargetConfiguration = new Dictionary<System.String, Amazon.IoT.Model.AuditNotificationTarget>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuditNotificationTargetConfiguration.Keys)
                {
                    context.AuditNotificationTargetConfiguration.Add((String)hashKey, (Amazon.IoT.Model.AuditNotificationTarget)(this.AuditNotificationTargetConfiguration[hashKey]));
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
            
            if (cmdletContext.AuditCheckConfiguration != null)
            {
                request.AuditCheckConfigurations = cmdletContext.AuditCheckConfiguration;
            }
            if (cmdletContext.AuditNotificationTargetConfiguration != null)
            {
                request.AuditNotificationTargetConfigurations = cmdletContext.AuditNotificationTargetConfiguration;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.UpdateAccountAuditConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.IoT.Model.AuditCheckConfiguration> AuditCheckConfiguration { get; set; }
            public Dictionary<System.String, Amazon.IoT.Model.AuditNotificationTarget> AuditNotificationTargetConfiguration { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateAccountAuditConfigurationResponse, UpdateIOTAccountAuditConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
