/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Creates one or more virtual tapes. You write data to the virtual tapes and then archive
    /// the tapes. This operation is only supported in tape gateways.
    /// 
    ///  <note><para>
    /// Cache storage must be allocated to the gateway before you can create virtual tapes.
    /// Use the <a>AddCache</a> operation to add cache storage to a gateway. 
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SGTape", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateTapes operation against AWS Storage Gateway.", Operation = new[] {"CreateTapes"}, LegacyAlias="New-SGTapes")]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.StorageGateway.Model.CreateTapesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGTapeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you use to retry a request. If you retry a request, use the
        /// same <code>ClientToken</code> you specified in the initial request.</para><note><para>Using the same <code>ClientToken</code> prevents creating the tape multiple times.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// <para>The unique Amazon Resource Name (ARN) that represents the gateway to associate the
        /// virtual tapes with. Use the <a>ListGateways</a> operation to return a list of gateways
        /// for your account and region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter NumTapesToCreate
        /// <summary>
        /// <para>
        /// <para>The number of virtual tapes that you want to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NumTapesToCreate { get; set; }
        #endregion
        
        #region Parameter TapeBarcodePrefix
        /// <summary>
        /// <para>
        /// <para>A prefix that you append to the barcode of the virtual tape you are creating. This
        /// prefix makes the barcode unique.</para><note><para>The prefix must be 1 to 4 characters in length and must be one of the uppercase letters
        /// from A to Z.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TapeBarcodePrefix { get; set; }
        #endregion
        
        #region Parameter TapeSizeInBytes
        /// <summary>
        /// <para>
        /// <para>The size, in bytes, of the virtual tapes that you want to create.</para><note><para>The size must be aligned by gigabyte (1024*1024*1024 byte).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 TapeSizeInBytes { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GatewayARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGTape (CreateTapes)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            context.GatewayARN = this.GatewayARN;
            if (ParameterWasBound("NumTapesToCreate"))
                context.NumTapesToCreate = this.NumTapesToCreate;
            context.TapeBarcodePrefix = this.TapeBarcodePrefix;
            if (ParameterWasBound("TapeSizeInBytes"))
                context.TapeSizeInBytes = this.TapeSizeInBytes;
            
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
            var request = new Amazon.StorageGateway.Model.CreateTapesRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.NumTapesToCreate != null)
            {
                request.NumTapesToCreate = cmdletContext.NumTapesToCreate.Value;
            }
            if (cmdletContext.TapeBarcodePrefix != null)
            {
                request.TapeBarcodePrefix = cmdletContext.TapeBarcodePrefix;
            }
            if (cmdletContext.TapeSizeInBytes != null)
            {
                request.TapeSizeInBytes = cmdletContext.TapeSizeInBytes.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TapeARNs;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.StorageGateway.Model.CreateTapesResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateTapesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateTapes");
            #if DESKTOP
            return client.CreateTapes(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateTapesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Int32? NumTapesToCreate { get; set; }
            public System.String TapeBarcodePrefix { get; set; }
            public System.Int64? TapeSizeInBytes { get; set; }
        }
        
    }
}
