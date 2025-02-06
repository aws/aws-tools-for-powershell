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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Describes the specified registry in detail.
    /// </summary>
    [Cmdlet("Get", "GLUERegistry")]
    [OutputType("Amazon.Glue.Model.GetRegistryResponse")]
    [AWSCmdlet("Calls the AWS Glue GetRegistry API operation.", Operation = new[] {"GetRegistry"}, SelectReturnType = typeof(Amazon.Glue.Model.GetRegistryResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.GetRegistryResponse",
        "This cmdlet returns an Amazon.Glue.Model.GetRegistryResponse object containing multiple properties."
    )]
    public partial class GetGLUERegistryCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RegistryId_RegistryArn
        /// <summary>
        /// <para>
        /// <para>Arn of the registry to be updated. One of <c>RegistryArn</c> or <c>RegistryName</c>
        /// has to be provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetRegistryResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetRegistryResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetRegistryResponse, GetGLUERegistryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.Glue.Model.GetRegistryRequest();
            
            
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
        
        private Amazon.Glue.Model.GetRegistryResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetRegistryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetRegistry");
            try
            {
                #if DESKTOP
                return client.GetRegistry(request);
                #elif CORECLR
                return client.GetRegistryAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Glue.Model.GetRegistryResponse, GetGLUERegistryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
