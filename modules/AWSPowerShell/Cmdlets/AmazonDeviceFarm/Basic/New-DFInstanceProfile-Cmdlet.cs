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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Creates a profile that can be applied to one or more private fleet device instances.
    /// </summary>
    [Cmdlet("New", "DFInstanceProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.InstanceProfile")]
    [AWSCmdlet("Calls the AWS Device Farm CreateInstanceProfile API operation.", Operation = new[] {"CreateInstanceProfile"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.InstanceProfile",
        "This cmdlet returns a InstanceProfile object.",
        "The service call response (type Amazon.DeviceFarm.Model.CreateInstanceProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDFInstanceProfileCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of your instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExcludeAppPackagesFromCleanup
        /// <summary>
        /// <para>
        /// <para>An array of strings specifying the list of app packages that should not be cleaned
        /// up from the device after a test run is over.</para><para>The list of packages is only considered if you set <code>packageCleanup</code> to
        /// <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ExcludeAppPackagesFromCleanup { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of your instance profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PackageCleanup
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code>, Device Farm will remove app packages after a test run.
        /// The default value is <code>false</code> for private devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PackageCleanup { get; set; }
        #endregion
        
        #region Parameter RebootAfterUse
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code>, Device Farm will reboot the instance after a test run.
        /// The default value is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RebootAfterUse { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DFInstanceProfile (CreateInstanceProfile)"))
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
            if (this.ExcludeAppPackagesFromCleanup != null)
            {
                context.ExcludeAppPackagesFromCleanup = new List<System.String>(this.ExcludeAppPackagesFromCleanup);
            }
            context.Name = this.Name;
            if (ParameterWasBound("PackageCleanup"))
                context.PackageCleanup = this.PackageCleanup;
            if (ParameterWasBound("RebootAfterUse"))
                context.RebootAfterUse = this.RebootAfterUse;
            
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
            var request = new Amazon.DeviceFarm.Model.CreateInstanceProfileRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExcludeAppPackagesFromCleanup != null)
            {
                request.ExcludeAppPackagesFromCleanup = cmdletContext.ExcludeAppPackagesFromCleanup;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PackageCleanup != null)
            {
                request.PackageCleanup = cmdletContext.PackageCleanup.Value;
            }
            if (cmdletContext.RebootAfterUse != null)
            {
                request.RebootAfterUse = cmdletContext.RebootAfterUse.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceProfile;
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
        
        private Amazon.DeviceFarm.Model.CreateInstanceProfileResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.CreateInstanceProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "CreateInstanceProfile");
            try
            {
                #if DESKTOP
                return client.CreateInstanceProfile(request);
                #elif CORECLR
                return client.CreateInstanceProfileAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ExcludeAppPackagesFromCleanup { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? PackageCleanup { get; set; }
            public System.Boolean? RebootAfterUse { get; set; }
        }
        
    }
}
