/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Keyspaces;
using Amazon.Keyspaces.Model;

namespace Amazon.PowerShell.Cmdlets.KS
{
    /// <summary>
    /// The <c>CreateType</c> operation creates a new user-defined type in the specified
    /// keyspace. 
    /// 
    ///  
    /// <para>
    /// To configure the required permissions, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/configure-udt-permissions.html#udt-permissions-create">Permissions
    /// to create a UDT</a> in the <i>Amazon Keyspaces Developer Guide</i>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/keyspaces/latest/devguide/udts.html">User-defined
    /// types (UDTs)</a> in the <i>Amazon Keyspaces Developer Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "KSType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Keyspaces.Model.CreateTypeResponse")]
    [AWSCmdlet("Calls the Amazon Keyspaces CreateType API operation.", Operation = new[] {"CreateType"}, SelectReturnType = typeof(Amazon.Keyspaces.Model.CreateTypeResponse))]
    [AWSCmdletOutput("Amazon.Keyspaces.Model.CreateTypeResponse",
        "This cmdlet returns an Amazon.Keyspaces.Model.CreateTypeResponse object containing multiple properties."
    )]
    public partial class NewKSTypeCmdlet : AmazonKeyspacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FieldDefinition
        /// <summary>
        /// <para>
        /// <para> The field definitions, consisting of names and types, that define this type. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FieldDefinitions")]
        public Amazon.Keyspaces.Model.FieldDefinition[] FieldDefinition { get; set; }
        #endregion
        
        #region Parameter KeyspaceName
        /// <summary>
        /// <para>
        /// <para> The name of the keyspace. </para>
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
        public System.String KeyspaceName { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para> The name of the user-defined type. </para><para>UDT names must contain 48 characters or less, must begin with an alphabetic character,
        /// and can only contain alpha-numeric characters and underscores. Amazon Keyspaces converts
        /// upper case characters automatically into lower case characters. </para><para>Alternatively, you can declare a UDT name in double quotes. When declaring a UDT name
        /// inside double quotes, Amazon Keyspaces preserves upper casing and allows special characters.</para><para>You can also use double quotes as part of the name when you create the UDT, but you
        /// must escape each double quote character with an additional double quote character.</para>
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
        public System.String TypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Keyspaces.Model.CreateTypeResponse).
        /// Specifying the name of a property of type Amazon.Keyspaces.Model.CreateTypeResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KSType (CreateType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Keyspaces.Model.CreateTypeResponse, NewKSTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FieldDefinition != null)
            {
                context.FieldDefinition = new List<Amazon.Keyspaces.Model.FieldDefinition>(this.FieldDefinition);
            }
            #if MODULAR
            if (this.FieldDefinition == null && ParameterWasBound(nameof(this.FieldDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter FieldDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyspaceName = this.KeyspaceName;
            #if MODULAR
            if (this.KeyspaceName == null && ParameterWasBound(nameof(this.KeyspaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyspaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TypeName = this.TypeName;
            #if MODULAR
            if (this.TypeName == null && ParameterWasBound(nameof(this.TypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter TypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Keyspaces.Model.CreateTypeRequest();
            
            if (cmdletContext.FieldDefinition != null)
            {
                request.FieldDefinitions = cmdletContext.FieldDefinition;
            }
            if (cmdletContext.KeyspaceName != null)
            {
                request.KeyspaceName = cmdletContext.KeyspaceName;
            }
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
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
        
        private Amazon.Keyspaces.Model.CreateTypeResponse CallAWSServiceOperation(IAmazonKeyspaces client, Amazon.Keyspaces.Model.CreateTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Keyspaces", "CreateType");
            try
            {
                return client.CreateTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Keyspaces.Model.FieldDefinition> FieldDefinition { get; set; }
            public System.String KeyspaceName { get; set; }
            public System.String TypeName { get; set; }
            public System.Func<Amazon.Keyspaces.Model.CreateTypeResponse, NewKSTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
