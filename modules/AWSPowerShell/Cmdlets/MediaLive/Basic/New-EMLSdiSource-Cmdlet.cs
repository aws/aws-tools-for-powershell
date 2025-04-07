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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Create an SdiSource for each video source that uses the SDI protocol. You will reference
    /// the SdiSource when you create an SDI input in MediaLive. You will also reference it
    /// in an SdiSourceMapping, in order to create a connection between the logical SdiSource
    /// and the physical SDI card and port that the physical SDI source uses.
    /// </summary>
    [Cmdlet("New", "EMLSdiSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.SdiSource")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateSdiSource API operation.", Operation = new[] {"CreateSdiSource"}, SelectReturnType = typeof(Amazon.MediaLive.Model.CreateSdiSourceResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.SdiSource or Amazon.MediaLive.Model.CreateSdiSourceResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.SdiSource object.",
        "The service call response (type Amazon.MediaLive.Model.CreateSdiSourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEMLSdiSourceCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// Applies only if the type is QUAD. Specify the mode
        /// for handling the quad-link signal: QUADRANT or INTERLEAVE.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.SdiSourceMode")]
        public Amazon.MediaLive.SdiSourceMode Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Specify a name that is unique in the AWS account.
        /// We recommend you assign a name that describes the source, for example curling-cameraA.
        /// Names are case-sensitive.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// An ID that you assign to a create request. This
        /// ID ensures idempotency when creating resources.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// Specify the  type of the SDI source: SINGLE: The
        /// source  is a single-link source. QUAD: The source  is one part of a quad-link source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.SdiSourceType")]
        public Amazon.MediaLive.SdiSourceType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SdiSource'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.CreateSdiSourceResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.CreateSdiSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SdiSource";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLSdiSource (CreateSdiSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.CreateSdiSourceResponse, NewEMLSdiSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Mode = this.Mode;
            context.Name = this.Name;
            context.RequestId = this.RequestId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            
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
            var request = new Amazon.MediaLive.Model.CreateSdiSourceRequest();
            
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.MediaLive.Model.CreateSdiSourceResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateSdiSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateSdiSource");
            try
            {
                #if DESKTOP
                return client.CreateSdiSource(request);
                #elif CORECLR
                return client.CreateSdiSourceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.SdiSourceMode Mode { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.MediaLive.SdiSourceType Type { get; set; }
            public System.Func<Amazon.MediaLive.Model.CreateSdiSourceResponse, NewEMLSdiSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SdiSource;
        }
        
    }
}
