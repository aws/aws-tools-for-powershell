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
    /// Creates a virtual tape by using your own barcode. You write data to the virtual tape
    /// and then archive the tape.
    /// 
    ///  <note><para>
    /// Cache storage must be allocated to the gateway before you can create a virtual tape.
    /// Use the <a>AddCache</a> operation to add cache storage to a gateway.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SGTapeWithBarcode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateTapeWithBarcode operation against AWS Storage Gateway.", Operation = new[] {"CreateTapeWithBarcode"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.StorageGateway.Model.CreateTapeWithBarcodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewSGTapeWithBarcodeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// <para>The unique Amazon Resource Name (ARN) that represents the gateway to associate the
        /// virtual tape with. Use the <a>ListGateways</a> operation to return a list of gateways
        /// for your account and region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter TapeBarcode
        /// <summary>
        /// <para>
        /// <para>The barcode that you want to assign to the tape.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String TapeBarcode { get; set; }
        #endregion
        
        #region Parameter TapeSizeInByte
        /// <summary>
        /// <para>
        /// <para>The size, in bytes, of the virtual tape that you want to create.</para><note><para>The size must be aligned by gigabyte (1024*1024*1024 byte).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TapeSizeInBytes")]
        public System.Int64 TapeSizeInByte { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGTapeWithBarcode (CreateTapeWithBarcode)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.GatewayARN = this.GatewayARN;
            context.TapeBarcode = this.TapeBarcode;
            if (ParameterWasBound("TapeSizeInByte"))
                context.TapeSizeInBytes = this.TapeSizeInByte;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.StorageGateway.Model.CreateTapeWithBarcodeRequest();
            
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.TapeBarcode != null)
            {
                request.TapeBarcode = cmdletContext.TapeBarcode;
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
                var response = client.CreateTapeWithBarcode(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TapeARN;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String GatewayARN { get; set; }
            public System.String TapeBarcode { get; set; }
            public System.Int64? TapeSizeInBytes { get; set; }
        }
        
    }
}
