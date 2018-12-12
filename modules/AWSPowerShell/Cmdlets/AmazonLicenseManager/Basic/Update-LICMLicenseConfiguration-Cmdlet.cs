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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Modifies the attributes of an existing license configuration object. A license configuration
    /// is an abstraction of a customer license agreement that can be consumed and enforced
    /// by License Manager. Components include specifications for the license type (Instances,
    /// cores, sockets, VCPUs), tenancy (shared or Dedicated Host), host affinity (how long
    /// a VM is associated with a host), the number of licenses purchased and used.
    /// </summary>
    [Cmdlet("Update", "LICMLicenseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS License Manager UpdateLicenseConfiguration API operation.", Operation = new[] {"UpdateLicenseConfiguration"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LicenseConfigurationArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLICMLicenseConfigurationCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>New human-friendly description of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LicenseConfigurationArn
        /// <summary>
        /// <para>
        /// <para>ARN for a license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LicenseConfigurationArn { get; set; }
        #endregion
        
        #region Parameter LicenseConfigurationStatus
        /// <summary>
        /// <para>
        /// <para>New status of the license configuration (<code>ACTIVE</code> or <code>INACTIVE</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LicenseManager.LicenseConfigurationStatus")]
        public Amazon.LicenseManager.LicenseConfigurationStatus LicenseConfigurationStatus { get; set; }
        #endregion
        
        #region Parameter LicenseCount
        /// <summary>
        /// <para>
        /// <para>New number of licenses managed by the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 LicenseCount { get; set; }
        #endregion
        
        #region Parameter LicenseCountHardLimit
        /// <summary>
        /// <para>
        /// <para>Sets the number of available licenses as a hard limit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean LicenseCountHardLimit { get; set; }
        #endregion
        
        #region Parameter LicenseRule
        /// <summary>
        /// <para>
        /// <para>List of flexible text strings designating license rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LicenseRules")]
        public System.String[] LicenseRule { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>New name of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the LicenseConfigurationArn parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LicenseConfigurationArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LICMLicenseConfiguration (UpdateLicenseConfiguration)"))
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
            
            context.Description = this.Description;
            context.LicenseConfigurationArn = this.LicenseConfigurationArn;
            context.LicenseConfigurationStatus = this.LicenseConfigurationStatus;
            if (ParameterWasBound("LicenseCount"))
                context.LicenseCount = this.LicenseCount;
            if (ParameterWasBound("LicenseCountHardLimit"))
                context.LicenseCountHardLimit = this.LicenseCountHardLimit;
            if (this.LicenseRule != null)
            {
                context.LicenseRules = new List<System.String>(this.LicenseRule);
            }
            context.Name = this.Name;
            
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
            var request = new Amazon.LicenseManager.Model.UpdateLicenseConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LicenseConfigurationArn != null)
            {
                request.LicenseConfigurationArn = cmdletContext.LicenseConfigurationArn;
            }
            if (cmdletContext.LicenseConfigurationStatus != null)
            {
                request.LicenseConfigurationStatus = cmdletContext.LicenseConfigurationStatus;
            }
            if (cmdletContext.LicenseCount != null)
            {
                request.LicenseCount = cmdletContext.LicenseCount.Value;
            }
            if (cmdletContext.LicenseCountHardLimit != null)
            {
                request.LicenseCountHardLimit = cmdletContext.LicenseCountHardLimit.Value;
            }
            if (cmdletContext.LicenseRules != null)
            {
                request.LicenseRules = cmdletContext.LicenseRules;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
                    pipelineOutput = this.LicenseConfigurationArn;
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
        
        private Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.UpdateLicenseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "UpdateLicenseConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateLicenseConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateLicenseConfigurationAsync(request);
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
            public System.String Description { get; set; }
            public System.String LicenseConfigurationArn { get; set; }
            public Amazon.LicenseManager.LicenseConfigurationStatus LicenseConfigurationStatus { get; set; }
            public System.Int64? LicenseCount { get; set; }
            public System.Boolean? LicenseCountHardLimit { get; set; }
            public List<System.String> LicenseRules { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
