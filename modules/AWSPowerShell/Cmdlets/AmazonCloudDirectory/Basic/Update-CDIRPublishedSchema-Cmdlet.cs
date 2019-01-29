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
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Upgrades a published schema under a new minor version revision using the current contents
    /// of <code>DevelopmentSchemaArn</code>.
    /// </summary>
    [Cmdlet("Update", "CDIRPublishedSchema", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cloud Directory UpgradePublishedSchema API operation.", Operation = new[] {"UpgradePublishedSchema"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCDIRPublishedSchemaCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter DevelopmentSchemaArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the development schema with the changes used for the upgrade.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DevelopmentSchemaArn { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Used for testing whether the Development schema provided is backwards compatible,
        /// or not, with the publish schema provided by the user to be upgraded. If schema compatibility
        /// fails, an exception would be thrown else the call would succeed. This parameter is
        /// optional and defaults to false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DryRun { get; set; }
        #endregion
        
        #region Parameter MinorVersion
        /// <summary>
        /// <para>
        /// <para>Identifies the minor version of the published schema that will be created. This parameter
        /// is NOT optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MinorVersion { get; set; }
        #endregion
        
        #region Parameter PublishedSchemaArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the published schema to be upgraded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PublishedSchemaArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DevelopmentSchemaArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CDIRPublishedSchema (UpgradePublishedSchema)"))
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
            
            context.DevelopmentSchemaArn = this.DevelopmentSchemaArn;
            if (ParameterWasBound("DryRun"))
                context.DryRun = this.DryRun;
            context.MinorVersion = this.MinorVersion;
            context.PublishedSchemaArn = this.PublishedSchemaArn;
            
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
            var request = new Amazon.CloudDirectory.Model.UpgradePublishedSchemaRequest();
            
            if (cmdletContext.DevelopmentSchemaArn != null)
            {
                request.DevelopmentSchemaArn = cmdletContext.DevelopmentSchemaArn;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MinorVersion != null)
            {
                request.MinorVersion = cmdletContext.MinorVersion;
            }
            if (cmdletContext.PublishedSchemaArn != null)
            {
                request.PublishedSchemaArn = cmdletContext.PublishedSchemaArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.UpgradedSchemaArn;
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
        
        private Amazon.CloudDirectory.Model.UpgradePublishedSchemaResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.UpgradePublishedSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "UpgradePublishedSchema");
            try
            {
                #if DESKTOP
                return client.UpgradePublishedSchema(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpgradePublishedSchemaAsync(request);
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
            public System.String DevelopmentSchemaArn { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String MinorVersion { get; set; }
            public System.String PublishedSchemaArn { get; set; }
        }
        
    }
}
