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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// This API is in preview release for Amazon Connect and is subject to change.
    /// 
    ///  
    /// <para>
    /// Initiates an Amazon Connect instance with all the supported channels enabled. It does
    /// not attach any storage, such as Amazon Simple Storage Service (Amazon S3) or Amazon
    /// Kinesis. It also does not allow for any configurations on features, such as Contact
    /// Lens for Amazon Connect. 
    /// </para><para>
    /// Amazon Connect enforces a limit on the total number of instances that you can create
    /// or delete in 30 days. If you exceed this limit, you will get an error message indicating
    /// there has been an excessive number of attempts at creating or deleting instances.
    /// You must wait 30 days before you can restart creating and deleting instances in your
    /// account.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CONNInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateInstanceResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateInstance API operation.", Operation = new[] {"CreateInstance"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateInstanceResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateInstanceResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateInstanceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCONNInstanceCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier for the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter IdentityManagementType
        /// <summary>
        /// <para>
        /// <para>The type of identity management for your Amazon Connect users.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.DirectoryType")]
        public Amazon.Connect.DirectoryType IdentityManagementType { get; set; }
        #endregion
        
        #region Parameter InboundCallsEnabled
        /// <summary>
        /// <para>
        /// <para>Your contact center handles incoming contacts.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? InboundCallsEnabled { get; set; }
        #endregion
        
        #region Parameter InstanceAlias
        /// <summary>
        /// <para>
        /// <para>The name for your instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceAlias { get; set; }
        #endregion
        
        #region Parameter OutboundCallsEnabled
        /// <summary>
        /// <para>
        /// <para>Your contact center allows outbound calls.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? OutboundCallsEnabled { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateInstanceResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNInstance (CreateInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateInstanceResponse, NewCONNInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DirectoryId = this.DirectoryId;
            context.IdentityManagementType = this.IdentityManagementType;
            #if MODULAR
            if (this.IdentityManagementType == null && ParameterWasBound(nameof(this.IdentityManagementType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityManagementType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InboundCallsEnabled = this.InboundCallsEnabled;
            #if MODULAR
            if (this.InboundCallsEnabled == null && ParameterWasBound(nameof(this.InboundCallsEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter InboundCallsEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceAlias = this.InstanceAlias;
            context.OutboundCallsEnabled = this.OutboundCallsEnabled;
            #if MODULAR
            if (this.OutboundCallsEnabled == null && ParameterWasBound(nameof(this.OutboundCallsEnabled)))
            {
                WriteWarning("You are passing $null as a value for parameter OutboundCallsEnabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.CreateInstanceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.IdentityManagementType != null)
            {
                request.IdentityManagementType = cmdletContext.IdentityManagementType;
            }
            if (cmdletContext.InboundCallsEnabled != null)
            {
                request.InboundCallsEnabled = cmdletContext.InboundCallsEnabled.Value;
            }
            if (cmdletContext.InstanceAlias != null)
            {
                request.InstanceAlias = cmdletContext.InstanceAlias;
            }
            if (cmdletContext.OutboundCallsEnabled != null)
            {
                request.OutboundCallsEnabled = cmdletContext.OutboundCallsEnabled.Value;
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
        
        private Amazon.Connect.Model.CreateInstanceResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateInstance");
            try
            {
                #if DESKTOP
                return client.CreateInstance(request);
                #elif CORECLR
                return client.CreateInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DirectoryId { get; set; }
            public Amazon.Connect.DirectoryType IdentityManagementType { get; set; }
            public System.Boolean? InboundCallsEnabled { get; set; }
            public System.String InstanceAlias { get; set; }
            public System.Boolean? OutboundCallsEnabled { get; set; }
            public System.Func<Amazon.Connect.Model.CreateInstanceResponse, NewCONNInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
