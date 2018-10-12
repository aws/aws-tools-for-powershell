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
using Amazon.OpsWorksCM;
using Amazon.OpsWorksCM.Model;

namespace Amazon.PowerShell.Cmdlets.OWCM
{
    /// <summary>
    /// Exports a specified server engine attribute as a base64-encoded string. For example,
    /// you can export user data that you can use in EC2 to associate nodes with a server.
    /// 
    /// 
    ///  
    /// <para>
    ///  This operation is synchronous. 
    /// </para><para>
    ///  A <code>ValidationException</code> is raised when parameters of the request are not
    /// valid. A <code>ResourceNotFoundException</code> is thrown when the server does not
    /// exist. An <code>InvalidStateException</code> is thrown when the server is in any of
    /// the following states: CREATING, TERMINATED, FAILED or DELETING. 
    /// </para>
    /// </summary>
    [Cmdlet("Export", "OWCMServerEngineAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse")]
    [AWSCmdlet("Calls the AWS OpsWorksCM ExportServerEngineAttribute API operation.", Operation = new[] {"ExportServerEngineAttribute"})]
    [AWSCmdletOutput("Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse",
        "This cmdlet returns a Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ExportOWCMServerEngineAttributeCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        #region Parameter ExportAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the export attribute. Currently supported export attribute is "Userdata"
        /// which exports a userdata script filled out with parameters provided in the <code>InputAttributes</code>
        /// list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExportAttributeName { get; set; }
        #endregion
        
        #region Parameter InputAttribute
        /// <summary>
        /// <para>
        /// <para>The list of engine attributes. The list type is <code>EngineAttribute</code>. <code>EngineAttribute</code>
        /// is a pair of attribute name and value. For <code>ExportAttributeName</code> "Userdata",
        /// currently supported input attribute names are: - "RunList": For Chef, an ordered list
        /// of roles and/or recipes that are run in the exact order. For Puppet, this parameter
        /// is ignored. - "OrganizationName": For Chef, an organization name. AWS OpsWorks for
        /// Chef Server always creates the organization "default". For Puppet, this parameter
        /// is ignored. - "NodeEnvironment": For Chef, a node environment (eg. development, staging,
        /// onebox). For Puppet, this parameter is ignored. - "NodeClientVersion": For Chef, version
        /// of Chef Engine (3 numbers separated by dots, eg. "13.8.5"). If empty, it uses the
        /// latest one. For Puppet, this parameter is ignored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InputAttributes")]
        public Amazon.OpsWorksCM.Model.EngineAttribute[] InputAttribute { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the Server to which the attribute is being exported from </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ServerName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-OWCMServerEngineAttribute (ExportServerEngineAttribute)"))
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
            
            context.ExportAttributeName = this.ExportAttributeName;
            if (this.InputAttribute != null)
            {
                context.InputAttributes = new List<Amazon.OpsWorksCM.Model.EngineAttribute>(this.InputAttribute);
            }
            context.ServerName = this.ServerName;
            
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
            var request = new Amazon.OpsWorksCM.Model.ExportServerEngineAttributeRequest();
            
            if (cmdletContext.ExportAttributeName != null)
            {
                request.ExportAttributeName = cmdletContext.ExportAttributeName;
            }
            if (cmdletContext.InputAttributes != null)
            {
                request.InputAttributes = cmdletContext.InputAttributes;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.ExportServerEngineAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorksCM", "ExportServerEngineAttribute");
            try
            {
                #if DESKTOP
                return client.ExportServerEngineAttribute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ExportServerEngineAttributeAsync(request);
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
            public System.String ExportAttributeName { get; set; }
            public List<Amazon.OpsWorksCM.Model.EngineAttribute> InputAttributes { get; set; }
            public System.String ServerName { get; set; }
        }
        
    }
}
