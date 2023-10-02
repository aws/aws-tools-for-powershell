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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Delete the entire registry including schema and all of its versions. To get the status
    /// of the delete operation, you can call the <code>GetRegistry</code> API after the asynchronous
    /// call. Deleting a registry will deactivate all online operations for the registry such
    /// as the <code>UpdateRegistry</code>, <code>CreateSchema</code>, <code>UpdateSchema</code>,
    /// and <code>RegisterSchemaVersion</code> APIs.
    /// </summary>
    [Cmdlet("Remove", "GLUERegistry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Glue.Model.DeleteRegistryResponse")]
    [AWSCmdlet("Calls the AWS Glue DeleteRegistry API operation.", Operation = new[] {"DeleteRegistry"}, SelectReturnType = typeof(Amazon.Glue.Model.DeleteRegistryResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.DeleteRegistryResponse",
        "This cmdlet returns an Amazon.Glue.Model.DeleteRegistryResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveGLUERegistryCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RegistryId_RegistryArn
        /// <summary>
        /// <para>
        /// <para>Arn of the registry to be updated. One of <code>RegistryArn</code> or <code>RegistryName</code>
        /// has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RegistryId_RegistryArn { get; set; }
        #endregion
        
        #region Parameter RegistryId_RegistryName
        /// <summary>
        /// <para>
        /// <para>Name of the registry. Used only for lookup. One of <code>RegistryArn</code> or <code>RegistryName</code>
        /// has to be provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId_RegistryName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.DeleteRegistryResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.DeleteRegistryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RegistryId_RegistryArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RegistryId_RegistryArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RegistryId_RegistryArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-GLUERegistry (DeleteRegistry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.DeleteRegistryResponse, RemoveGLUERegistryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RegistryId_RegistryArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.Glue.Model.DeleteRegistryRequest();
            
            
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
        
        private Amazon.Glue.Model.DeleteRegistryResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.DeleteRegistryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "DeleteRegistry");
            try
            {
                #if DESKTOP
                return client.DeleteRegistry(request);
                #elif CORECLR
                return client.DeleteRegistryAsync(request).GetAwaiter().GetResult();
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
            public System.String RegistryId_RegistryArn { get; set; }
            public System.String RegistryId_RegistryName { get; set; }
            public System.Func<Amazon.Glue.Model.DeleteRegistryResponse, RemoveGLUERegistryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
