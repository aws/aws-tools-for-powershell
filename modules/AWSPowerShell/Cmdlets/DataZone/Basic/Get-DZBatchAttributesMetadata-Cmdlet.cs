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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Gets the attribute metadata.
    /// </summary>
    [Cmdlet("Get", "DZBatchAttributesMetadata")]
    [OutputType("Amazon.DataZone.Model.BatchGetAttributesMetadataResponse")]
    [AWSCmdlet("Calls the Amazon DataZone BatchGetAttributesMetadata API operation.", Operation = new[] {"BatchGetAttributesMetadata"}, SelectReturnType = typeof(Amazon.DataZone.Model.BatchGetAttributesMetadataResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.BatchGetAttributesMetadataResponse",
        "This cmdlet returns an Amazon.DataZone.Model.BatchGetAttributesMetadataResponse object containing multiple properties."
    )]
    public partial class GetDZBatchAttributesMetadataCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeIdentifier
        /// <summary>
        /// <para>
        /// <para>The attribute identifier.</para>
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
        [Alias("AttributeIdentifiers")]
        public System.String[] AttributeIdentifier { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The domain ID where you want to get the attribute metadata.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter EntityIdentifier
        /// <summary>
        /// <para>
        /// <para>The entity ID for which you want to get attribute metadata.</para>
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
        public System.String EntityIdentifier { get; set; }
        #endregion
        
        #region Parameter EntityRevision
        /// <summary>
        /// <para>
        /// <para>The entity revision for which you want to get attribute metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntityRevision { get; set; }
        #endregion
        
        #region Parameter EntityType
        /// <summary>
        /// <para>
        /// <para>The entity type for which you want to get attribute metadata.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataZone.AttributeEntityType")]
        public Amazon.DataZone.AttributeEntityType EntityType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.BatchGetAttributesMetadataResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.BatchGetAttributesMetadataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.BatchGetAttributesMetadataResponse, GetDZBatchAttributesMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeIdentifier != null)
            {
                context.AttributeIdentifier = new List<System.String>(this.AttributeIdentifier);
            }
            #if MODULAR
            if (this.AttributeIdentifier == null && ParameterWasBound(nameof(this.AttributeIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityIdentifier = this.EntityIdentifier;
            #if MODULAR
            if (this.EntityIdentifier == null && ParameterWasBound(nameof(this.EntityIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityRevision = this.EntityRevision;
            context.EntityType = this.EntityType;
            #if MODULAR
            if (this.EntityType == null && ParameterWasBound(nameof(this.EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataZone.Model.BatchGetAttributesMetadataRequest();
            
            if (cmdletContext.AttributeIdentifier != null)
            {
                request.AttributeIdentifiers = cmdletContext.AttributeIdentifier;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EntityIdentifier != null)
            {
                request.EntityIdentifier = cmdletContext.EntityIdentifier;
            }
            if (cmdletContext.EntityRevision != null)
            {
                request.EntityRevision = cmdletContext.EntityRevision;
            }
            if (cmdletContext.EntityType != null)
            {
                request.EntityType = cmdletContext.EntityType;
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
        
        private Amazon.DataZone.Model.BatchGetAttributesMetadataResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.BatchGetAttributesMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "BatchGetAttributesMetadata");
            try
            {
                #if DESKTOP
                return client.BatchGetAttributesMetadata(request);
                #elif CORECLR
                return client.BatchGetAttributesMetadataAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributeIdentifier { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String EntityIdentifier { get; set; }
            public System.String EntityRevision { get; set; }
            public Amazon.DataZone.AttributeEntityType EntityType { get; set; }
            public System.Func<Amazon.DataZone.Model.BatchGetAttributesMetadataResponse, GetDZBatchAttributesMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
