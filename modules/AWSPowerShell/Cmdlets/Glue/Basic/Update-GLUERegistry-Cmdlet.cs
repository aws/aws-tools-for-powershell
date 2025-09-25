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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Updates an existing registry which is used to hold a collection of schemas. The updated
    /// properties relate to the registry, and do not modify any of the schemas within the
    /// registry.
    /// </summary>
    [Cmdlet("Update", "GLUERegistry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.UpdateRegistryResponse")]
    [AWSCmdlet("Calls the AWS Glue UpdateRegistry API operation.", Operation = new[] {"UpdateRegistry"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateRegistryResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.UpdateRegistryResponse",
        "This cmdlet returns an Amazon.Glue.Model.UpdateRegistryResponse object containing multiple properties."
    )]
    public partial class UpdateGLUERegistryCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the registry. If description is not provided, this field will not
        /// be updated.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RegistryId_RegistryArn
        /// <summary>
        /// <para>
        /// <para>Arn of the registry to be updated. One of <c>RegistryArn</c> or <c>RegistryName</c>
        /// has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId_RegistryArn { get; set; }
        #endregion
        
        #region Parameter RegistryId_RegistryName
        /// <summary>
        /// <para>
        /// <para>Name of the registry. Used only for lookup. One of <c>RegistryArn</c> or <c>RegistryName</c>
        /// has to be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId_RegistryName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateRegistryResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.UpdateRegistryResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Description), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUERegistry (UpdateRegistry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateRegistryResponse, UpdateGLUERegistryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistryId_RegistryArn = this.RegistryId_RegistryArn;
            context.RegistryId_RegistryName = this.RegistryId_RegistryName;
            
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
            var request = new Amazon.Glue.Model.UpdateRegistryRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate RegistryId
            var requestRegistryIdIsNull = true;
            request.RegistryId = new Amazon.Glue.Model.RegistryId();
            System.String requestRegistryId_registryId_RegistryArn = null;
            if (cmdletContext.RegistryId_RegistryArn != null)
            {
                requestRegistryId_registryId_RegistryArn = cmdletContext.RegistryId_RegistryArn;
            }
            if (requestRegistryId_registryId_RegistryArn != null)
            {
                request.RegistryId.RegistryArn = requestRegistryId_registryId_RegistryArn;
                requestRegistryIdIsNull = false;
            }
            System.String requestRegistryId_registryId_RegistryName = null;
            if (cmdletContext.RegistryId_RegistryName != null)
            {
                requestRegistryId_registryId_RegistryName = cmdletContext.RegistryId_RegistryName;
            }
            if (requestRegistryId_registryId_RegistryName != null)
            {
                request.RegistryId.RegistryName = requestRegistryId_registryId_RegistryName;
                requestRegistryIdIsNull = false;
            }
             // determine if request.RegistryId should be set to null
            if (requestRegistryIdIsNull)
            {
                request.RegistryId = null;
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
        
        private Amazon.Glue.Model.UpdateRegistryResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateRegistryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateRegistry");
            try
            {
                return client.UpdateRegistryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String RegistryId_RegistryArn { get; set; }
            public System.String RegistryId_RegistryName { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateRegistryResponse, UpdateGLUERegistryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
