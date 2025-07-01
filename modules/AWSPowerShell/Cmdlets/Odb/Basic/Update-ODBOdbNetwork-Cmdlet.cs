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
using Amazon.Odb;
using Amazon.Odb.Model;

namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Updates properties of a specified ODB network.
    /// </summary>
    [Cmdlet("Update", "ODBOdbNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.UpdateOdbNetworkResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services UpdateOdbNetwork API operation.", Operation = new[] {"UpdateOdbNetwork"}, SelectReturnType = typeof(Amazon.Odb.Model.UpdateOdbNetworkResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.UpdateOdbNetworkResponse",
        "This cmdlet returns an Amazon.Odb.Model.UpdateOdbNetworkResponse object containing multiple properties."
    )]
    public partial class UpdateODBOdbNetworkCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The new user-friendly name of the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter OdbNetworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ODB network to update.</para>
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
        public System.String OdbNetworkId { get; set; }
        #endregion
        
        #region Parameter PeeredCidrsToBeAdded
        /// <summary>
        /// <para>
        /// <para>The list of CIDR ranges from the peered VPC that allow access to the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PeeredCidrsToBeAdded { get; set; }
        #endregion
        
        #region Parameter PeeredCidrsToBeRemoved
        /// <summary>
        /// <para>
        /// <para>The list of CIDR ranges from the peered VPC to remove from the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PeeredCidrsToBeRemoved { get; set; }
        #endregion
        
        #region Parameter S3Access
        /// <summary>
        /// <para>
        /// <para>Specifies the updated configuration for Amazon S3 access from the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.Access")]
        public Amazon.Odb.Access S3Access { get; set; }
        #endregion
        
        #region Parameter S3PolicyDocument
        /// <summary>
        /// <para>
        /// <para>Specifies the updated endpoint policy for Amazon S3 access from the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3PolicyDocument { get; set; }
        #endregion
        
        #region Parameter ZeroEtlAccess
        /// <summary>
        /// <para>
        /// <para>Specifies the updated configuration for Zero-ETL access from the ODB network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.Access")]
        public Amazon.Odb.Access ZeroEtlAccess { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.UpdateOdbNetworkResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.UpdateOdbNetworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OdbNetworkId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OdbNetworkId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OdbNetworkId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OdbNetworkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ODBOdbNetwork (UpdateOdbNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.UpdateOdbNetworkResponse, UpdateODBOdbNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OdbNetworkId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DisplayName = this.DisplayName;
            context.OdbNetworkId = this.OdbNetworkId;
            #if MODULAR
            if (this.OdbNetworkId == null && ParameterWasBound(nameof(this.OdbNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter OdbNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PeeredCidrsToBeAdded != null)
            {
                context.PeeredCidrsToBeAdded = new List<System.String>(this.PeeredCidrsToBeAdded);
            }
            if (this.PeeredCidrsToBeRemoved != null)
            {
                context.PeeredCidrsToBeRemoved = new List<System.String>(this.PeeredCidrsToBeRemoved);
            }
            context.S3Access = this.S3Access;
            context.S3PolicyDocument = this.S3PolicyDocument;
            context.ZeroEtlAccess = this.ZeroEtlAccess;
            
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
            var request = new Amazon.Odb.Model.UpdateOdbNetworkRequest();
            
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.OdbNetworkId != null)
            {
                request.OdbNetworkId = cmdletContext.OdbNetworkId;
            }
            if (cmdletContext.PeeredCidrsToBeAdded != null)
            {
                request.PeeredCidrsToBeAdded = cmdletContext.PeeredCidrsToBeAdded;
            }
            if (cmdletContext.PeeredCidrsToBeRemoved != null)
            {
                request.PeeredCidrsToBeRemoved = cmdletContext.PeeredCidrsToBeRemoved;
            }
            if (cmdletContext.S3Access != null)
            {
                request.S3Access = cmdletContext.S3Access;
            }
            if (cmdletContext.S3PolicyDocument != null)
            {
                request.S3PolicyDocument = cmdletContext.S3PolicyDocument;
            }
            if (cmdletContext.ZeroEtlAccess != null)
            {
                request.ZeroEtlAccess = cmdletContext.ZeroEtlAccess;
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
        
        private Amazon.Odb.Model.UpdateOdbNetworkResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.UpdateOdbNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "UpdateOdbNetwork");
            try
            {
                #if DESKTOP
                return client.UpdateOdbNetwork(request);
                #elif CORECLR
                return client.UpdateOdbNetworkAsync(request).GetAwaiter().GetResult();
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
            public System.String DisplayName { get; set; }
            public System.String OdbNetworkId { get; set; }
            public List<System.String> PeeredCidrsToBeAdded { get; set; }
            public List<System.String> PeeredCidrsToBeRemoved { get; set; }
            public Amazon.Odb.Access S3Access { get; set; }
            public System.String S3PolicyDocument { get; set; }
            public Amazon.Odb.Access ZeroEtlAccess { get; set; }
            public System.Func<Amazon.Odb.Model.UpdateOdbNetworkResponse, UpdateODBOdbNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
