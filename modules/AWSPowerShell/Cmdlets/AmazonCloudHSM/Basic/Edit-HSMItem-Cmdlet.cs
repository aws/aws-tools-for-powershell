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
    /// Modifies an HSM.
    /// 
    ///  <important><para>
    /// This operation can result in the HSM being offline for up to 15 minutes while the
    /// AWS CloudHSM service is reconfigured. If you are modifying a production HSM, you should
    /// ensure that your AWS CloudHSM service is configured for high availability, and consider
    /// executing this operation during a maintenance window.
    /// </para></important>
    /// </summary>
    [Cmdlet("Edit", "HSMItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ModifyHsm operation against AWS Cloud HSM.", Operation = new[] {"ModifyHsm"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudHSM.Model.ModifyHsmResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditHSMItemCmdlet : AmazonCloudHSMClientCmdlet, IExecutor
    {
        
        #region Parameter EniIp
        /// <summary>
        /// <para>
        /// <para>The new IP address for the elastic network interface (ENI) attached to the HSM.</para><para>If the HSM is moved to a different subnet, and an IP address is not specified, an
        /// IP address will be randomly chosen from the CIDR range of the new subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EniIp { get; set; }
        #endregion
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>The new external ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter HsmArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the HSM to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String HsmArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The new IAM role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The new identifier of the subnet that the HSM is in. The new subnet must be in the
        /// same Availability Zone as the current subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter SyslogIp
        /// <summary>
        /// <para>
        /// <para>The new IP address for the syslog monitoring server. The AWS CloudHSM service only
        /// supports one syslog monitoring server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SyslogIp { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("HsmArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-HSMItem (ModifyHsm)"))
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
            
            context.EniIp = this.EniIp;
            context.ExternalId = this.ExternalId;
            context.HsmArn = this.HsmArn;
            context.IamRoleArn = this.IamRoleArn;
            context.SubnetId = this.SubnetId;
            context.SyslogIp = this.SyslogIp;
            
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
            var request = new Amazon.CloudHSM.Model.ModifyHsmRequest();
            
            if (cmdletContext.EniIp != null)
            {
                request.EniIp = cmdletContext.EniIp;
            }
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.HsmArn != null)
            {
                request.HsmArn = cmdletContext.HsmArn;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.SyslogIp != null)
            {
                request.SyslogIp = cmdletContext.SyslogIp;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.HsmArn;
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
        
        private Amazon.CloudHSM.Model.ModifyHsmResponse CallAWSServiceOperation(IAmazonCloudHSM client, Amazon.CloudHSM.Model.ModifyHsmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud HSM", "ModifyHsm");
            try
            {
                #if DESKTOP
                return client.ModifyHsm(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyHsmAsync(request);
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
            public System.String EniIp { get; set; }
            public System.String ExternalId { get; set; }
            public System.String HsmArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String SubnetId { get; set; }
            public System.String SyslogIp { get; set; }
        }
        
    }
}
