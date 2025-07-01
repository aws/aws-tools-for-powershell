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
    /// Returns information about the specified database server.
    /// </summary>
    [Cmdlet("Get", "ODBDbServer")]
    [OutputType("Amazon.Odb.Model.DbServer")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services GetDbServer API operation.", Operation = new[] {"GetDbServer"}, SelectReturnType = typeof(Amazon.Odb.Model.GetDbServerResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.DbServer or Amazon.Odb.Model.GetDbServerResponse",
        "This cmdlet returns an Amazon.Odb.Model.DbServer object.",
        "The service call response (type Amazon.Odb.Model.GetDbServerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetODBDbServerCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudExadataInfrastructureId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Oracle Exadata infrastructure that contains the database
        /// server.</para>
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
        public System.String CloudExadataInfrastructureId { get; set; }
        #endregion
        
        #region Parameter DbServerId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the database server to retrieve information about.</para>
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
        public System.String DbServerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DbServer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.GetDbServerResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.GetDbServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DbServer";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DbServerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DbServerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DbServerId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.GetDbServerResponse, GetODBDbServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DbServerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudExadataInfrastructureId = this.CloudExadataInfrastructureId;
            #if MODULAR
            if (this.CloudExadataInfrastructureId == null && ParameterWasBound(nameof(this.CloudExadataInfrastructureId)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudExadataInfrastructureId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DbServerId = this.DbServerId;
            #if MODULAR
            if (this.DbServerId == null && ParameterWasBound(nameof(this.DbServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter DbServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Odb.Model.GetDbServerRequest();
            
            if (cmdletContext.CloudExadataInfrastructureId != null)
            {
                request.CloudExadataInfrastructureId = cmdletContext.CloudExadataInfrastructureId;
            }
            if (cmdletContext.DbServerId != null)
            {
                request.DbServerId = cmdletContext.DbServerId;
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
        
        private Amazon.Odb.Model.GetDbServerResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.GetDbServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "GetDbServer");
            try
            {
                #if DESKTOP
                return client.GetDbServer(request);
                #elif CORECLR
                return client.GetDbServerAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudExadataInfrastructureId { get; set; }
            public System.String DbServerId { get; set; }
            public System.Func<Amazon.Odb.Model.GetDbServerResponse, GetODBDbServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DbServer;
        }
        
    }
}
