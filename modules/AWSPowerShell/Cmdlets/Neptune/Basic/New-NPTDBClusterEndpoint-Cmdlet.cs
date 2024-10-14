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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Creates a new custom endpoint and associates it with an Amazon Neptune DB cluster.
    /// </summary>
    [Cmdlet("New", "NPTDBClusterEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.CreateDBClusterEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Neptune CreateDBClusterEndpoint API operation.", Operation = new[] {"CreateDBClusterEndpoint"}, SelectReturnType = typeof(Amazon.Neptune.Model.CreateDBClusterEndpointResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.CreateDBClusterEndpointResponse",
        "This cmdlet returns an Amazon.Neptune.Model.CreateDBClusterEndpointResponse object containing multiple properties."
    )]
    public partial class NewNPTDBClusterEndpointCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBClusterEndpointIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier to use for the new endpoint. This parameter is stored as a lowercase
        /// string.</para>
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
        public System.String DBClusterEndpointIdentifier { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier of the DB cluster associated with the endpoint. This parameter
        /// is stored as a lowercase string.</para>
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
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of the endpoint. One of: <c>READER</c>, <c>WRITER</c>, <c>ANY</c>.</para>
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
        public System.String EndpointType { get; set; }
        #endregion
        
        #region Parameter ExcludedMember
        /// <summary>
        /// <para>
        /// <para>List of DB instance identifiers that aren't part of the custom endpoint group. All
        /// other eligible instances are reachable through the custom endpoint. Only relevant
        /// if the list of static members is empty.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludedMembers")]
        public System.String[] ExcludedMember { get; set; }
        #endregion
        
        #region Parameter StaticMember
        /// <summary>
        /// <para>
        /// <para>List of DB instance identifiers that are part of the custom endpoint group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StaticMembers")]
        public System.String[] StaticMember { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the Amazon Neptune resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Neptune.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.CreateDBClusterEndpointResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.CreateDBClusterEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBClusterEndpointIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBClusterEndpointIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBClusterEndpointIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterEndpointIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NPTDBClusterEndpoint (CreateDBClusterEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.CreateDBClusterEndpointResponse, NewNPTDBClusterEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBClusterEndpointIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBClusterEndpointIdentifier = this.DBClusterEndpointIdentifier;
            #if MODULAR
            if (this.DBClusterEndpointIdentifier == null && ParameterWasBound(nameof(this.DBClusterEndpointIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterEndpointIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointType = this.EndpointType;
            #if MODULAR
            if (this.EndpointType == null && ParameterWasBound(nameof(this.EndpointType)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExcludedMember != null)
            {
                context.ExcludedMember = new List<System.String>(this.ExcludedMember);
            }
            if (this.StaticMember != null)
            {
                context.StaticMember = new List<System.String>(this.StaticMember);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Neptune.Model.Tag>(this.Tag);
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
            var request = new Amazon.Neptune.Model.CreateDBClusterEndpointRequest();
            
            if (cmdletContext.DBClusterEndpointIdentifier != null)
            {
                request.DBClusterEndpointIdentifier = cmdletContext.DBClusterEndpointIdentifier;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
            }
            if (cmdletContext.ExcludedMember != null)
            {
                request.ExcludedMembers = cmdletContext.ExcludedMember;
            }
            if (cmdletContext.StaticMember != null)
            {
                request.StaticMembers = cmdletContext.StaticMember;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Neptune.Model.CreateDBClusterEndpointResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.CreateDBClusterEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "CreateDBClusterEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateDBClusterEndpoint(request);
                #elif CORECLR
                return client.CreateDBClusterEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterEndpointIdentifier { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String EndpointType { get; set; }
            public List<System.String> ExcludedMember { get; set; }
            public List<System.String> StaticMember { get; set; }
            public List<Amazon.Neptune.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Neptune.Model.CreateDBClusterEndpointResponse, NewNPTDBClusterEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
