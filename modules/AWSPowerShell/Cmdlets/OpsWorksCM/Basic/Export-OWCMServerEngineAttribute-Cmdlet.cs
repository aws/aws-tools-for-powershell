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
    [AWSCmdlet("Calls the AWS OpsWorksCM ExportServerEngineAttribute API operation.", Operation = new[] {"ExportServerEngineAttribute"}, SelectReturnType = typeof(Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse))]
    [AWSCmdletOutput("Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse",
        "This cmdlet returns an Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ExportOWCMServerEngineAttributeCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExportAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the export attribute. Currently, the supported export attribute is <code>Userdata</code>.
        /// This exports a user data script that includes parameters and values provided in the
        /// <code>InputAttributes</code> list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ExportAttributeName { get; set; }
        #endregion
        
        #region Parameter InputAttribute
        /// <summary>
        /// <para>
        /// <para>The list of engine attributes. The list type is <code>EngineAttribute</code>. An <code>EngineAttribute</code>
        /// list item is a pair that includes an attribute name and its value. For the <code>Userdata</code>
        /// ExportAttributeName, the following are supported engine attribute names.</para><ul><li><para><b>RunList</b> In Chef, a list of roles or recipes that are run in the specified
        /// order. In Puppet, this parameter is ignored.</para></li><li><para><b>OrganizationName</b> In Chef, an organization name. AWS OpsWorks for Chef Automate
        /// always creates the organization <code>default</code>. In Puppet, this parameter is
        /// ignored.</para></li><li><para><b>NodeEnvironment</b> In Chef, a node environment (for example, development, staging,
        /// or one-box). In Puppet, this parameter is ignored.</para></li><li><para><b>NodeClientVersion</b> In Chef, the version of the Chef engine (three numbers separated
        /// by dots, such as 13.8.5). If this attribute is empty, OpsWorks for Chef Automate uses
        /// the most current version. In Puppet, this parameter is ignored.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputAttributes")]
        public Amazon.OpsWorksCM.Model.EngineAttribute[] InputAttribute { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the server from which you are exporting the attribute.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse).
        /// Specifying the name of a property of type Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-OWCMServerEngineAttribute (ExportServerEngineAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse, ExportOWCMServerEngineAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExportAttributeName = this.ExportAttributeName;
            #if MODULAR
            if (this.ExportAttributeName == null && ParameterWasBound(nameof(this.ExportAttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportAttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputAttribute != null)
            {
                context.InputAttribute = new List<Amazon.OpsWorksCM.Model.EngineAttribute>(this.InputAttribute);
            }
            context.ServerName = this.ServerName;
            #if MODULAR
            if (this.ServerName == null && ParameterWasBound(nameof(this.ServerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            if (cmdletContext.InputAttribute != null)
            {
                request.InputAttributes = cmdletContext.InputAttribute;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
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
        
        private Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.ExportServerEngineAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorksCM", "ExportServerEngineAttribute");
            try
            {
                #if DESKTOP
                return client.ExportServerEngineAttribute(request);
                #elif CORECLR
                return client.ExportServerEngineAttributeAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.OpsWorksCM.Model.EngineAttribute> InputAttribute { get; set; }
            public System.String ServerName { get; set; }
            public System.Func<Amazon.OpsWorksCM.Model.ExportServerEngineAttributeResponse, ExportOWCMServerEngineAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
