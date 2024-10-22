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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Retrieves an ID namespace association from a specific collaboration.
    /// </summary>
    [Cmdlet("Get", "CRSCollaborationIdNamespaceAssociation")]
    [OutputType("Amazon.CleanRooms.Model.CollaborationIdNamespaceAssociation")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service GetCollaborationIdNamespaceAssociation API operation.", Operation = new[] {"GetCollaborationIdNamespaceAssociation"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.CollaborationIdNamespaceAssociation or Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.CollaborationIdNamespaceAssociation object.",
        "The service call response (type Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCRSCollaborationIdNamespaceAssociationCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CollaborationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the collaboration that contains the ID namespace association
        /// that you want to retrieve.</para>
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
        public System.String CollaborationIdentifier { get; set; }
        #endregion
        
        #region Parameter IdNamespaceAssociationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ID namespace association that you want to retrieve.</para>
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
        public System.String IdNamespaceAssociationIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CollaborationIdNamespaceAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CollaborationIdNamespaceAssociation";
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
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse, GetCRSCollaborationIdNamespaceAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollaborationIdentifier = this.CollaborationIdentifier;
            #if MODULAR
            if (this.CollaborationIdentifier == null && ParameterWasBound(nameof(this.CollaborationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter CollaborationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdNamespaceAssociationIdentifier = this.IdNamespaceAssociationIdentifier;
            #if MODULAR
            if (this.IdNamespaceAssociationIdentifier == null && ParameterWasBound(nameof(this.IdNamespaceAssociationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IdNamespaceAssociationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationRequest();
            
            if (cmdletContext.CollaborationIdentifier != null)
            {
                request.CollaborationIdentifier = cmdletContext.CollaborationIdentifier;
            }
            if (cmdletContext.IdNamespaceAssociationIdentifier != null)
            {
                request.IdNamespaceAssociationIdentifier = cmdletContext.IdNamespaceAssociationIdentifier;
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
        
        private Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "GetCollaborationIdNamespaceAssociation");
            try
            {
                #if DESKTOP
                return client.GetCollaborationIdNamespaceAssociation(request);
                #elif CORECLR
                return client.GetCollaborationIdNamespaceAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String CollaborationIdentifier { get; set; }
            public System.String IdNamespaceAssociationIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.GetCollaborationIdNamespaceAssociationResponse, GetCRSCollaborationIdNamespaceAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CollaborationIdNamespaceAssociation;
        }
        
    }
}
