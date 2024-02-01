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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Creates a new playback restriction policy, for constraining playback by countries
    /// and/or origins.
    /// </summary>
    [Cmdlet("New", "IVSPlaybackRestrictionPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.PlaybackRestrictionPolicy")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service CreatePlaybackRestrictionPolicy API operation.", Operation = new[] {"CreatePlaybackRestrictionPolicy"}, SelectReturnType = typeof(Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.PlaybackRestrictionPolicy or Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse",
        "This cmdlet returns an Amazon.IVS.Model.PlaybackRestrictionPolicy object.",
        "The service call response (type Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIVSPlaybackRestrictionPolicyCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowedCountry
        /// <summary>
        /// <para>
        /// <para>A list of country codes that control geoblocking restriction. Allowed values are the
        /// officially assigned <a href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO
        /// 3166-1 alpha-2</a> codes. Default: All countries (an empty array).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedCountries")]
        public System.String[] AllowedCountry { get; set; }
        #endregion
        
        #region Parameter AllowedOrigin
        /// <summary>
        /// <para>
        /// <para>A list of origin sites that control CORS restriction. Allowed values are the same
        /// as valid values of the Origin header defined at <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Origin">https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Origin</a>.
        /// Default: All origins (an empty array).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedOrigins")]
        public System.String[] AllowedOrigin { get; set; }
        #endregion
        
        #region Parameter EnableStrictOriginEnforcement
        /// <summary>
        /// <para>
        /// <para>Whether channel playback is constrained by origin site. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableStrictOriginEnforcement { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Playback-restriction-policy name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Array of 1-50 maps, each of the form <c>string:string (key:value)</c>. See <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a> for more information, including restrictions that
        /// apply to tags and "Tag naming limits and requirements"; Amazon IVS has no service-specific
        /// constraints beyond what is documented there.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PlaybackRestrictionPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PlaybackRestrictionPolicy";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IVSPlaybackRestrictionPolicy (CreatePlaybackRestrictionPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse, NewIVSPlaybackRestrictionPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedCountry != null)
            {
                context.AllowedCountry = new List<System.String>(this.AllowedCountry);
            }
            if (this.AllowedOrigin != null)
            {
                context.AllowedOrigin = new List<System.String>(this.AllowedOrigin);
            }
            context.EnableStrictOriginEnforcement = this.EnableStrictOriginEnforcement;
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.IVS.Model.CreatePlaybackRestrictionPolicyRequest();
            
            if (cmdletContext.AllowedCountry != null)
            {
                request.AllowedCountries = cmdletContext.AllowedCountry;
            }
            if (cmdletContext.AllowedOrigin != null)
            {
                request.AllowedOrigins = cmdletContext.AllowedOrigin;
            }
            if (cmdletContext.EnableStrictOriginEnforcement != null)
            {
                request.EnableStrictOriginEnforcement = cmdletContext.EnableStrictOriginEnforcement.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.CreatePlaybackRestrictionPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "CreatePlaybackRestrictionPolicy");
            try
            {
                #if DESKTOP
                return client.CreatePlaybackRestrictionPolicy(request);
                #elif CORECLR
                return client.CreatePlaybackRestrictionPolicyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedCountry { get; set; }
            public List<System.String> AllowedOrigin { get; set; }
            public System.Boolean? EnableStrictOriginEnforcement { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IVS.Model.CreatePlaybackRestrictionPolicyResponse, NewIVSPlaybackRestrictionPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PlaybackRestrictionPolicy;
        }
        
    }
}
