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
using Amazon.MigrationHub;
using Amazon.MigrationHub.Model;

namespace Amazon.PowerShell.Cmdlets.MH
{
    /// <summary>
    /// Provides identifying details of the resource being migrated so that it can be associated
    /// in the Application Discovery Service (ADS)'s repository. This association occurs asynchronously
    /// after <code>PutResourceAttributes</code> returns.
    /// 
    ///  <important><para>
    /// Keep in mind that subsequent calls to PutResourceAttributes will override previously
    /// stored attributes. For example, if it is first called with a MAC address, but later,
    /// it is desired to <i>add</i> an IP address, it will then be required to call it with
    /// <i>both</i> the IP and MAC addresses to prevent overiding the MAC address.
    /// </para></important><note><para>
    /// Because this is an asynchronous call, it will always return 200, whether an association
    /// occurs or not. To confirm if an association was found based on the provided details,
    /// call <code>ListAssociatedResource</code>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "MHResourceAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Migration Hub PutResourceAttributes API operation.", Operation = new[] {"PutResourceAttributes"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the MigrationTaskName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.MigrationHub.Model.PutResourceAttributesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetMHResourceAttributeCmdlet : AmazonMigrationHubClientCmdlet, IExecutor
    {
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Optional boolean flag to indicate whether any effect should take place. Used to test
        /// if the caller has permission to make the call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DryRun { get; set; }
        #endregion
        
        #region Parameter MigrationTaskName
        /// <summary>
        /// <para>
        /// <para>Unique identifier that references the migration task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String MigrationTaskName { get; set; }
        #endregion
        
        #region Parameter ProgressUpdateStream
        /// <summary>
        /// <para>
        /// <para>The name of the ProgressUpdateStream. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProgressUpdateStream { get; set; }
        #endregion
        
        #region Parameter ResourceAttributeList
        /// <summary>
        /// <para>
        /// <para>Information about the resource that is being migrated. This data will be used to map
        /// the task to a resource in the Application Discovery Service (ADS)'s repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MigrationHub.Model.ResourceAttribute[] ResourceAttributeList { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the MigrationTaskName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MigrationTaskName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-MHResourceAttribute (PutResourceAttributes)"))
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
            
            if (ParameterWasBound("DryRun"))
                context.DryRun = this.DryRun;
            context.MigrationTaskName = this.MigrationTaskName;
            context.ProgressUpdateStream = this.ProgressUpdateStream;
            if (this.ResourceAttributeList != null)
            {
                context.ResourceAttributeList = new List<Amazon.MigrationHub.Model.ResourceAttribute>(this.ResourceAttributeList);
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
            var request = new Amazon.MigrationHub.Model.PutResourceAttributesRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MigrationTaskName != null)
            {
                request.MigrationTaskName = cmdletContext.MigrationTaskName;
            }
            if (cmdletContext.ProgressUpdateStream != null)
            {
                request.ProgressUpdateStream = cmdletContext.ProgressUpdateStream;
            }
            if (cmdletContext.ResourceAttributeList != null)
            {
                request.ResourceAttributeList = cmdletContext.ResourceAttributeList;
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
                    pipelineOutput = this.MigrationTaskName;
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
        
        private Amazon.MigrationHub.Model.PutResourceAttributesResponse CallAWSServiceOperation(IAmazonMigrationHub client, Amazon.MigrationHub.Model.PutResourceAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub", "PutResourceAttributes");
            try
            {
                #if DESKTOP
                return client.PutResourceAttributes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutResourceAttributesAsync(request);
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
            public System.Boolean? DryRun { get; set; }
            public System.String MigrationTaskName { get; set; }
            public System.String ProgressUpdateStream { get; set; }
            public List<Amazon.MigrationHub.Model.ResourceAttribute> ResourceAttributeList { get; set; }
        }
        
    }
}
