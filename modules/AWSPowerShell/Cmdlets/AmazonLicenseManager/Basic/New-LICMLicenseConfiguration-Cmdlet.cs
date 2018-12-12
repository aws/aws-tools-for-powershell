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
    /// Creates a new license configuration object. A license configuration is an abstraction
    /// of a customer license agreement that can be consumed and enforced by License Manager.
    /// Components include specifications for the license type (licensing by instance, socket,
    /// CPU, or VCPU), tenancy (shared tenancy, Amazon EC2 Dedicated Instance, Amazon EC2
    /// Dedicated Host, or any of these), host affinity (how long a VM must be associated
    /// with a host), the number of licenses purchased and used.
    /// </summary>
    [Cmdlet("New", "LICMLicenseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS License Manager CreateLicenseConfiguration API operation.", Operation = new[] {"CreateLicenseConfiguration"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLICMLicenseConfigurationCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Human-friendly description of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LicenseCount
        /// <summary>
        /// <para>
        /// <para>Number of licenses managed by the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 LicenseCount { get; set; }
        #endregion
        
        #region Parameter LicenseCountHardLimit
        /// <summary>
        /// <para>
        /// <para>Flag indicating whether hard or soft license enforcement is used. Exceeding a hard
        /// limit results in the blocked deployment of new instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean LicenseCountHardLimit { get; set; }
        #endregion
        
        #region Parameter LicenseCountingType
        /// <summary>
        /// <para>
        /// <para>Dimension to use to track the license inventory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LicenseManager.LicenseCountingType")]
        public Amazon.LicenseManager.LicenseCountingType LicenseCountingType { get; set; }
        #endregion
        
        #region Parameter LicenseRule
        /// <summary>
        /// <para>
        /// <para>Array of configured License Manager rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LicenseRules")]
        public System.String[] LicenseRule { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the resources during launch. You can only tag instances and volumes
        /// on launch. The specified tags are applied to all instances or volumes that are created
        /// during launch. To tag a resource after it has been created, see CreateTags .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.LicenseManager.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMLicenseConfiguration (CreateLicenseConfiguration)"))
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
            if (ParameterWasBound("LicenseCount"))
                context.LicenseCount = this.LicenseCount;
            if (ParameterWasBound("LicenseCountHardLimit"))
                context.LicenseCountHardLimit = this.LicenseCountHardLimit;
            context.LicenseCountingType = this.LicenseCountingType;
            if (this.LicenseRule != null)
            {
                context.LicenseRules = new List<System.String>(this.LicenseRule);
            }
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.LicenseManager.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.LicenseManager.Model.CreateLicenseConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LicenseCount != null)
            {
                request.LicenseCount = cmdletContext.LicenseCount.Value;
            }
            if (cmdletContext.LicenseCountHardLimit != null)
            {
                request.LicenseCountHardLimit = cmdletContext.LicenseCountHardLimit.Value;
            }
            if (cmdletContext.LicenseCountingType != null)
            {
                request.LicenseCountingType = cmdletContext.LicenseCountingType;
            }
            if (cmdletContext.LicenseRules != null)
            {
                request.LicenseRules = cmdletContext.LicenseRules;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LicenseConfigurationArn;
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
        
        private Amazon.LicenseManager.Model.CreateLicenseConfigurationResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateLicenseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateLicenseConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateLicenseConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateLicenseConfigurationAsync(request);
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
            public System.Int64? LicenseCount { get; set; }
            public System.Boolean? LicenseCountHardLimit { get; set; }
            public Amazon.LicenseManager.LicenseCountingType LicenseCountingType { get; set; }
            public List<System.String> LicenseRules { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.LicenseManager.Model.Tag> Tags { get; set; }
        }
        
    }
}
